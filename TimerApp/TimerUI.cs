using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerApp
{
    public partial class TimerUI : UserControl
    {
        public TimeSpan timer;
        public Color WarningColor;
        public Color BackgroundColor;
        public bool DeleteFlag;
        private MainWindow _parent;
        private bool paused;
        private bool flash;

        public TimerUI(TimeSpan time, MainWindow parent)
        {
            InitializeComponent();
            timer = time;
            tmr_Tick.Interval = 1000;
            tmr_Tick.Start();
            WarningColor = parent.settings.warningFlash;
            BackgroundColor = parent.settings.background;
            BackColor = BackgroundColor;
            Font = parent.settings.font;
            _parent = parent;
        }

        private void btn_RemoveTimer_Click(object sender, EventArgs e)
        {
            DeleteFlag = true;
            _parent.RemoveTimer();
        }

        private void tmr_Tick_Tick(object sender, EventArgs e)
        {
            if (!paused)
            {
                timer = timer.Subtract(TimeSpan.FromSeconds(1));
                lbl_Time.Text = timer.ToString("h\\:m\\:s");
                if (timer.CompareTo(new TimeSpan(0, 15, 0)) <= 0)
                {
                    flash = !flash;
                    BackColor = flash ? WarningColor : BackgroundColor;
                    //Color temp = BackColor;
                    //BackColor = WarningColor;
                    //WarningColor = temp;
                }
                if (timer.CompareTo(TimeSpan.Zero) <= 0)
                {
                    tmr_Tick.Stop();
                    btn_RemoveTimer.Visible = true;
                    btn_Pause.Visible = false;
                }
            }
        }

        private void btn_AddTime_Click(object sender, EventArgs e)
        {
            using (addTime addTime = new addTime())
            {
                addTime.ShowDialog();
                if (addTime.DialogResult==DialogResult.OK)
                {
                    timer = timer.Add(new TimeSpan((int)addTime.num_Hours.Value, (int)addTime.num_Minutes.Value, 0));
                    btn_RemoveTimer.Visible = false;
                    btn_Pause.Visible = true;
                }
            }
        }

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            paused = !paused;
        }
    }
}
