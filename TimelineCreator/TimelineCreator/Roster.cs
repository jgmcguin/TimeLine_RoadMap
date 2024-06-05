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
    //This form allows you to see the List of people and a description of the person.
    public partial class Roster : Form
    {
        public Dictionary<string, List<string>> RosterList
        {
            get; set;
        }
        public Roster()
        {
            InitializeComponent();
        }

        private void Roster_Load(object sender, EventArgs e)
        {
            listRoster.Items.Clear();
            foreach(KeyValuePair<string, List<string>> name in RosterList)
            {
                listRoster.Items.Add(name.Key);
            }
        }

        private void listRoster_SelectedValueChanged(object sender, EventArgs e)
        {
            txtRoster.Text = "";
            for (int i = 0; i < RosterList[listRoster.SelectedItem.ToString()].Count; i++)
            {
                txtRoster.Text += RosterList[listRoster.SelectedItem.ToString()][i] + Environment.NewLine;
            }
        }
    }
}
