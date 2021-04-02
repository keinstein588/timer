namespace TimerApp
{
    partial class AddCustomer
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmb_Name = new System.Windows.Forms.ComboBox();
            this.btn_AddTimer = new System.Windows.Forms.Button();
            this.txt_Station = new System.Windows.Forms.TextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.num_hours = new System.Windows.Forms.NumericUpDown();
            this.num_minutes = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_overwrite = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_hours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_minutes)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_Name
            // 
            this.cmb_Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_Name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmb_Name.FormattingEnabled = true;
            this.cmb_Name.Location = new System.Drawing.Point(12, 12);
            this.cmb_Name.Name = "cmb_Name";
            this.cmb_Name.Size = new System.Drawing.Size(162, 21);
            this.cmb_Name.TabIndex = 0;
            this.cmb_Name.SelectedIndexChanged += new System.EventHandler(this.cmb_Name_SelectedIndexChanged);
            // 
            // btn_AddTimer
            // 
            this.btn_AddTimer.Location = new System.Drawing.Point(17, 82);
            this.btn_AddTimer.Name = "btn_AddTimer";
            this.btn_AddTimer.Size = new System.Drawing.Size(75, 23);
            this.btn_AddTimer.TabIndex = 2;
            this.btn_AddTimer.Text = "Add Timer";
            this.btn_AddTimer.UseVisualStyleBackColor = true;
            this.btn_AddTimer.Click += new System.EventHandler(this.btn_AddTimer_Click);
            // 
            // txt_Station
            // 
            this.txt_Station.Location = new System.Drawing.Point(180, 12);
            this.txt_Station.Name = "txt_Station";
            this.txt_Station.Size = new System.Drawing.Size(100, 20);
            this.txt_Station.TabIndex = 3;
            this.txt_Station.Text = "Station...";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(109, 82);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // num_hours
            // 
            this.num_hours.Location = new System.Drawing.Point(56, 39);
            this.num_hours.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.num_hours.Name = "num_hours";
            this.num_hours.Size = new System.Drawing.Size(36, 20);
            this.num_hours.TabIndex = 6;
            // 
            // num_minutes
            // 
            this.num_minutes.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.num_minutes.Location = new System.Drawing.Point(148, 39);
            this.num_minutes.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.num_minutes.Name = "num_minutes";
            this.num_minutes.Size = new System.Drawing.Size(36, 20);
            this.num_minutes.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Hours";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Minutes";
            // 
            // lbl_overwrite
            // 
            this.lbl_overwrite.AutoSize = true;
            this.lbl_overwrite.Location = new System.Drawing.Point(12, 41);
            this.lbl_overwrite.Name = "lbl_overwrite";
            this.lbl_overwrite.Size = new System.Drawing.Size(212, 13);
            this.lbl_overwrite.TabIndex = 10;
            this.lbl_overwrite.Text = "Customer has time saved from previous visit";
            this.lbl_overwrite.Visible = false;
            // 
            // AddCustomer
            // 
            this.AcceptButton = this.btn_AddTimer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(306, 129);
            this.Controls.Add(this.lbl_overwrite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num_minutes);
            this.Controls.Add(this.num_hours);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.txt_Station);
            this.Controls.Add(this.btn_AddTimer);
            this.Controls.Add(this.cmb_Name);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCustomer";
            this.ShowInTaskbar = false;
            this.Text = "AddCustomer";
            ((System.ComponentModel.ISupportInitialize)(this.num_hours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_minutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_AddTimer;
        public System.Windows.Forms.ComboBox cmb_Name;
        public System.Windows.Forms.TextBox txt_Station;
        private System.Windows.Forms.Button btn_Cancel;
        public System.Windows.Forms.NumericUpDown num_hours;
        public System.Windows.Forms.NumericUpDown num_minutes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_overwrite;
    }
}