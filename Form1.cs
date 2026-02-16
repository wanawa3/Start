using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Start
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnSportsmen_Click_1(object sender, EventArgs e)
        {
            SportsmenForm form = new SportsmenForm();
            form.ShowDialog();
        }

        private void btnCoaches_Click(object sender, EventArgs e)
        {
            var form = new CoachesForm();
            form.ShowDialog();
        }
    }
}
