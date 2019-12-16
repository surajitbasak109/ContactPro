using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace ContactPro
{
    public partial class FormMain : Office2007Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void districtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.FormDistricts fd = new forms.FormDistricts();
            fd.ShowDialog();
        }

        private void constiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.FormConstituency fcont = new forms.FormConstituency();
            fcont.ShowDialog();
        }

        private void panchayatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.FormPanchayat fpanch = new forms.FormPanchayat();
            fpanch.ShowDialog();
        }

        private void membershipEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.FormMembership fmem = new forms.FormMembership();
            fmem.ShowDialog();
        }
    }
}
