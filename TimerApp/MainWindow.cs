using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TimerApp
{
    public partial class MainWindow : Form
    {
        private List<Timer> timers;
        public bool datasetUpdated;
        private bool updateSettings;
        private readonly string filename = "customers.ls";
        private readonly string settingsFilename = "settings.set";
        private List<customer> customers;
        public Settings settings;

        public MainWindow()
        {
            InitializeComponent();
            timers = new List<Timer>();
            customers = new List<customer>();
            if (File.Exists(settingsFilename))
            {
                StreamReader reader = new StreamReader(settingsFilename);
                settings = new Settings();
                string FontFamilyName = reader.ReadLine();
                float FontSize = float.Parse(reader.ReadLine());
                settings.font = new Font(FontFamilyName, FontSize, FontStyle.Regular);
                settings.warningFlash = Color.FromArgb(int.Parse(reader.ReadLine()));
                settings.background = Color.FromArgb(int.Parse(reader.ReadLine()));
                BackColor = settings.background;
                reader.Close();
            }
            else
            {
                settings = new Settings()
                {
                    font = new Font(FontFamily.GenericSansSerif, 8.0f, FontStyle.Regular)
                    ,
                    background = Color.FromKnownColor(KnownColor.Control)
                    ,
                    warningFlash = Color.Red
                    ,
                };
                updateSettings = true;
            }
            if (File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename);
                string name;
                while ((name = reader.ReadLine()) != null)
                {
                    long ticks = 0;
                    if (name.Contains("&"))
                    {
                        string[] parts = name.Split('&');
                        ticks = long.Parse(parts[1]);
                        name = parts[0];
                    }
                    customers.Add(new customer(name, ticks));
                }
                reader.Close();
            }
        }

        private void AddCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AddCustomer addDialog = new AddCustomer(this) { customers = customers })
            {
                addDialog.InitCollection();
                addDialog.ShowDialog();
                if (addDialog.DialogResult == DialogResult.OK)
                {
                    TimeSpan time = customers.Find(c => c.name.CompareTo(addDialog.customerName) == 0) != null ? customers.Find(c => c.name.CompareTo(addDialog.customerName) == 0).time : new TimeSpan((int)addDialog.num_hours.Value, (int)addDialog.num_minutes.Value, 0);
                    TimerUI newTimer = new TimerUI(time, this);
                    newTimer.lbl_Name.Text = addDialog.customerName;
                    newTimer.lbl_Station.Text = addDialog.txt_Station.Text;
                    newTimer.lbl_Time.Text = newTimer.timer.ToString("h\\:m\\:s");
                    if (Controls.Count > 0)
                    {
                        newTimer.Top = Controls[Controls.Count - 1].Bottom + 5;
                    }
                    else
                    {
                        newTimer.Top = 25;
                    }
                    Controls.Add(newTimer);
                }
            }
        }

        public void RemoveTimer()
        {
            for (int i = Controls.Count-1; i>0;--i)
            {
                if (Controls[i] is TimerUI && (Controls[i] as TimerUI).DeleteFlag)
                {
                    TimerUI timer = Controls[i] as TimerUI;
                    customers.Find(x => x.name.CompareTo(timer.lbl_Name.Text) == 0).time = timer.timer;
                    datasetUpdated = true;
                    Controls.RemoveAt(i);
                }
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (datasetUpdated || Controls.Count > 0)
            {
                StreamWriter writer = new StreamWriter(filename, false);
                bool written;
                foreach (customer c in customers)
                {
                    written = false;
                    for (int i = Controls.Count - 1; i > 0; --i)
                    {
                        if (Controls[i] is TimerUI)
                        {
                            TimerUI timer = Controls[i] as TimerUI;
                            if (timer.timer.TotalSeconds <= 0)
                            {
                                Controls.RemoveAt(i);
                                continue;
                            }
                            if (timer.lbl_Name.Text.CompareTo(c.name) == 0)
                            {
                                writer.WriteLine($"{c.name}&{timer.timer.Ticks}");
                                written = true;
                                Controls.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    if (!written)
                    {
                        if (c.time.Ticks > 0)
                        {
                            writer.WriteLine($"{c.name}&{c.time.Ticks}");
                        }
                        else
                        {
                            writer.WriteLine(c.name);
                        }
                    }
                }
                writer.Close();
            }
            if (updateSettings)
            {
                StreamWriter writer = new StreamWriter(settingsFilename, false);
                settings.SaveSettings(writer);
                writer.Close();
            }
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fnd_FontDialog.ShowDialog() == DialogResult.OK)
            {
                updateSettings = true;
                settings.font = fnd_FontDialog.Font;
                foreach(Control c in Controls)
                {
                    if (c is TimerUI)
                    {
                        c.Font = settings.font;
                    }
                }
            }
        }

        private void changeFlashColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cld_WarningColorDialog.ShowDialog() == DialogResult.OK)
            {
                updateSettings = true;
                settings.warningFlash = cld_WarningColorDialog.Color;
                foreach (Control c in Controls)
                {
                    if (c is TimerUI)
                    {
                        (c as TimerUI).WarningColor = settings.warningFlash;
                    }
                }
            }
        }

        private void changeBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cld_BackgroundColorDialog.ShowDialog() == DialogResult.OK)
            {
                updateSettings = true;
                settings.background = cld_BackgroundColorDialog.Color;
                foreach (Control c in Controls)
                {
                    if (c is TimerUI)
                    {
                        (c as TimerUI).BackgroundColor = settings.background;
                        BackColor = settings.background;
                    }
                }
            }
        }

        private void removeCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (RemoveCustomer rc = new RemoveCustomer(customers, this))
            {

                if (rc.ShowDialog() == DialogResult.OK)
                {
                    customers = rc._customers;
                }
            }
        }

        private void removeTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (RemoveTime rt = new RemoveTime(customers, this))
            {
                if (rt.ShowDialog() == DialogResult.OK)
                {
                    customers = rt._customers;
                }
            }
        }
    }
}
