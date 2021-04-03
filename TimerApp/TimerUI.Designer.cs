namespace TimerApp
{
    partial class TimerUI
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_Station = new System.Windows.Forms.Label();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.btn_AddTime = new System.Windows.Forms.Button();
            this.btn_RemoveTimer = new System.Windows.Forms.Button();
            this.tmr_Tick = new System.Windows.Forms.Timer(this.components);
            this.btn_Pause = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_Name.Location = new System.Drawing.Point(0, 0);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.lbl_Name.Size = new System.Drawing.Size(122, 20);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "SomeLong NamePerson";
            // 
            // lbl_Station
            // 
            this.lbl_Station.AutoSize = true;
            this.lbl_Station.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_Station.Location = new System.Drawing.Point(122, 0);
            this.lbl_Station.Name = "lbl_Station";
            this.lbl_Station.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.lbl_Station.Size = new System.Drawing.Size(97, 20);
            this.lbl_Station.TabIndex = 1;
            this.lbl_Station.Text = "Station Name Here";
            // 
            // lbl_Time
            // 
            this.lbl_Time.AutoSize = true;
            this.lbl_Time.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_Time.Location = new System.Drawing.Point(219, 0);
            this.lbl_Time.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.lbl_Time.Size = new System.Drawing.Size(55, 20);
            this.lbl_Time.TabIndex = 2;
            this.lbl_Time.Text = "999:99:99";
            this.lbl_Time.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_AddTime
            // 
            this.btn_AddTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_AddTime.Location = new System.Drawing.Point(274, 0);
            this.btn_AddTime.Name = "btn_AddTime";
            this.btn_AddTime.Size = new System.Drawing.Size(75, 28);
            this.btn_AddTime.TabIndex = 3;
            this.btn_AddTime.Text = "Add Time";
            this.btn_AddTime.UseVisualStyleBackColor = true;
            this.btn_AddTime.Click += new System.EventHandler(this.btn_AddTime_Click);
            // 
            // btn_RemoveTimer
            // 
            this.btn_RemoveTimer.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_RemoveTimer.Location = new System.Drawing.Point(349, 0);
            this.btn_RemoveTimer.Name = "btn_RemoveTimer";
            this.btn_RemoveTimer.Size = new System.Drawing.Size(78, 28);
            this.btn_RemoveTimer.TabIndex = 4;
            this.btn_RemoveTimer.Text = "Pause";
            this.btn_RemoveTimer.UseVisualStyleBackColor = true;
            this.btn_RemoveTimer.Click += new System.EventHandler(this.btn_Pause_Click);
            // 
            // tmr_Tick
            // 
            this.tmr_Tick.Tick += new System.EventHandler(this.tmr_Tick_Tick);
            // 
            // btn_Pause
            // 
            this.btn_Pause.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Pause.Location = new System.Drawing.Point(427, 0);
            this.btn_Pause.Name = "btn_Pause";
            this.btn_Pause.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_Pause.Size = new System.Drawing.Size(94, 28);
            this.btn_Pause.TabIndex = 5;
            this.btn_Pause.Text = "Remove Timer";
            this.btn_Pause.UseVisualStyleBackColor = true;
            this.btn_Pause.Click += new System.EventHandler(this.btn_RemoveTimer_Click);
            // 
            // TimerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.btn_Pause);
            this.Controls.Add(this.btn_RemoveTimer);
            this.Controls.Add(this.btn_AddTime);
            this.Controls.Add(this.lbl_Time);
            this.Controls.Add(this.lbl_Station);
            this.Controls.Add(this.lbl_Name);
            this.MaximumSize = new System.Drawing.Size(0, 28);
            this.MinimumSize = new System.Drawing.Size(100, 28);
            this.Name = "TimerUI";
            this.Size = new System.Drawing.Size(521, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_AddTime;
        private System.Windows.Forms.Button btn_RemoveTimer;
        public System.Windows.Forms.Label lbl_Name;
        public System.Windows.Forms.Label lbl_Time;
        public System.Windows.Forms.Label lbl_Station;
        private System.Windows.Forms.Timer tmr_Tick;
        private System.Windows.Forms.Button btn_Pause;
    }
}
