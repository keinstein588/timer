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
        private readonly string filename = "customers.ls";
        private List<string> customers;

        public MainWindow()
        {
            InitializeComponent();
            timers = new List<Timer>();
            customers = new List<string>();
            if (File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename);
                string name;
                while ((name = reader.ReadLine()) != null)
                {
                    customers.Add(name);
                }
                reader.Close();
            }
        }

        private void AddCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AddCustomer addDialog = new AddCustomer(this) { customers = this.customers })
            {
                addDialog.InitCollection();
                addDialog.ShowDialog();
                if (addDialog.DialogResult == DialogResult.OK)
                {
                    TimerUI newTimer = new TimerUI(new TimeSpan((int)addDialog.num_hours.Value, (int)addDialog.num_minutes.Value, 0), this);
                    newTimer.lbl_Name.Text = addDialog.customerName;
                    newTimer.lbl_Station.Text = addDialog.txt_Station.Text;
                    newTimer.lbl_Time.Text = $"{(int)addDialog.num_hours.Value}:{(int)addDialog.num_minutes.Value}:0";
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
            //timers.Add(new Timer(11));
        }

        public void RemoveTimer()
        {
            for (int i = Controls.Count-1; i>0;--i)
            {
                if (Controls[i] is TimerUI && (Controls[i] as TimerUI).DeleteFlag)
                {
                    Controls.RemoveAt(i);
                }
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (datasetUpdated)
            {
                StreamWriter writer = new StreamWriter(filename, false);
                foreach (string s in customers)
                {
                    writer.WriteLine(s);
                }
                writer.Close();
            }
        }
    }
}
