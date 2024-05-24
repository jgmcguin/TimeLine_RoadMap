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
    public partial class Timeline : Form
    {
        public Dictionary<string, List<string>> TimeLineInfo
        {
            get; set;
        }
        public Timeline()
        {
            InitializeComponent();
        }

        private void Timeline_Load(object sender, EventArgs e)
        {

        }
    }
}
