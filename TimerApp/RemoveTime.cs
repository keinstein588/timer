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
    public partial class RemoveTime : Form
    {
        public List<customer> _customers;
        private MainWindow _parent;
        private List<string> names;
        private AutoCompleteStringCollection collection;
        public RemoveTime(List<customer> customers, MainWindow parent)
        {
            InitializeComponent();
            _customers = customers;
            _parent = parent;
            collection = new AutoCompleteStringCollection();
            names = new List<string>();
            foreach (customer c in customers)
            {
                if (c.time.Ticks > 0)
                {
                    names.Add(c.name);
                    collection.Add(c.name);
                }
            }
            txt_Name.AutoCompleteCustomSource = collection;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (names.Contains(txt_Name.Text))
            {
                customer c = _customers.First(x => x.name.CompareTo(txt_Name.Text) == 0);
                c.time = c.time.Add(new TimeSpan(-c.time.Ticks));
            }
            names.Remove(txt_Name.Text);
            _parent.datasetUpdated = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
