using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroX_database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newTube_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new new_tube_GUI()).ShowDialog();
        }

        private void EOLReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new EOLReportGUI()).ShowDialog();
        }

        private void SystemChange_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new SystemChange_GUI()).ShowDialog();
        }
    }
}
