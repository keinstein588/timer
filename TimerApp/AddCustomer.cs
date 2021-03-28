using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerApp
{
    public partial class AddCustomer : Form
    {
        public TimeSpan time;
        public string customerName;
        private MainWindow parentHolder;
        public List<string> customers;
        private AutoCompleteStringCollection collection;

        public AddCustomer( MainWindow parent)
        {
            InitializeComponent();
            parentHolder = parent;
        }

        public void InitCollection()
        {
            collection = new AutoCompleteStringCollection();
            collection.AddRange(customers.ToArray());
            cmb_Name.AutoCompleteCustomSource = collection;
            cmb_Name.Items.AddRange(customers.ToArray());
        }

        private void btn_AddTimer_Click(object sender, EventArgs e)
        {
            time = new TimeSpan((int)num_hours.Value, (int)num_minutes.Value, 0);
            if (time.CompareTo(TimeSpan.FromSeconds(0)) > 0)
            {
                if (!string.IsNullOrWhiteSpace(cmb_Name.Text))
                {
                    if (!collection.Contains(cmb_Name.Text))
                    {
                        customers.Add(cmb_Name.Text);
                        parentHolder.datasetUpdated = true;
                    }
                    customerName = cmb_Name.Text;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter a time of more than 15 minutes.", "Invalid Time");
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
