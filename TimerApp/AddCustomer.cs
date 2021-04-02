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
        public List<customer> customers;
        private AutoCompleteStringCollection collection;

        public AddCustomer( MainWindow parent)
        {
            InitializeComponent();
            parentHolder = parent;
        }

        public void InitCollection()
        {
            collection = new AutoCompleteStringCollection();
            foreach (customer c in customers)
            {
                if (string.IsNullOrWhiteSpace(c.name)) continue;
                collection.Add(c.name);
                cmb_Name.Items.Add(c.name);
            }
            //collection.AddRange(customers.ToArray());
            cmb_Name.AutoCompleteCustomSource = collection;
            //cmb_Name.Items.AddRange(collection.);
        }

        private void btn_AddTimer_Click(object sender, EventArgs e)
        {
            time = new TimeSpan((int)num_hours.Value, (int)num_minutes.Value, 0);
            if (time.CompareTo(TimeSpan.FromSeconds(0)) > 0 || lbl_overwrite.Visible)
            {
                if (!string.IsNullOrWhiteSpace(cmb_Name.Text))
                {
                    if (!collection.Contains(cmb_Name.Text))
                    {
                        customers.Add(new customer(cmb_Name.Text, new TimeSpan((int)num_hours.Value, (int)num_minutes.Value, 0).Ticks));
                        parentHolder.datasetUpdated = true;
                    }
                    else if (!lbl_overwrite.Visible)
                    {
                        customers.First(c => c.name.CompareTo(cmb_Name.Text) == 0).time = new TimeSpan((int)num_hours.Value, (int)num_minutes.Value, 0);
                        parentHolder.datasetUpdated = true;
                    }
                    customerName = cmb_Name.Text;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter a time of at least 15 minutes.", "Invalid Time");
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmb_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_overwrite.Visible = customers.Find(c => c.name.CompareTo(cmb_Name.Text) == 0).time.Ticks > 0;
        }
    }
}
