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
    public partial class RemoveCustomer : Form
    {
        public List<customer> _customers;
        private MainWindow _parent;
        private List<string> names;
        private AutoCompleteStringCollection collection;
        public RemoveCustomer(List<customer> customers, MainWindow parent)
        {
            InitializeComponent();
            _customers = customers;
            _parent = parent;
            collection = new AutoCompleteStringCollection();
            names = new List<string>();
            foreach(customer c in customers)
            {
                names.Add(c.name);
                collection.Add(c.name);
            }
            txt_Name.AutoCompleteCustomSource = collection;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (names.Contains(txt_Name.Text))
            {
                customer c = _customers.First(x => x.name.CompareTo(txt_Name.Text) == 0);
                if (c.time.Ticks <= 0 || MessageBox.Show($"{c.name} has time left from a previous visit. Are you sure you want to remove the customer?", "Confirm Customer Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _customers.Remove(_customers.First(x => x.name.CompareTo(txt_Name.Text) == 0));
                    _parent.datasetUpdated = true;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                MessageBox.Show($"{txt_Name.Text} was not found in the list of customers, please check the spelling.", "Could not find customer");
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
