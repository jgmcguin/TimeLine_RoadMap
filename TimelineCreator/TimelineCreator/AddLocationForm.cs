using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimelineCreator
{
    public partial class AddLocationForm : Form
    {
        public Dictionary<string, List<string>> Location_Info {  get; set; }
        public AddLocationForm()
        {
            InitializeComponent();
        }

        private void txtNewLoc_TextChanged(object sender, EventArgs e)
        {
        }

        private void UpdateLocations()
        {
            listLocations.Items.Clear();
            foreach (KeyValuePair<string, List<string>> location in Location_Info)
            {
                listLocations.Items.Add(location.Key);
            }
        }

        private void AddLocationForm_Load(object sender, EventArgs e)
        {
            UpdateLocations();
        }
    }
}
