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
        public List<Location> Location_Info {  get; set; }
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
            foreach (Location location in Location_Info)
            {
                listLocations.Items.Add(location.Name);
            }
        }

        private void AddLocationForm_Load(object sender, EventArgs e)
        {
            UpdateLocations();
        }

        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            if (txtNewLoc.Text != "")
                Location_Info.Add(new Location(txtNewLoc.Text, txtLocDesc.Text));
            UpdateLocations();
        }
    }
}
