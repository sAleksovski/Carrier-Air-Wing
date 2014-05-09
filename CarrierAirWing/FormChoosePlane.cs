using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarrierAirWing
{
    public partial class FormChoosePlane : Form
    {
        public FormChoosePlane()
        {
            InitializeComponent();
        }

        private void btnThunderbolt_Click(object sender, EventArgs e)
        {
            Settings.chosenPlane = 2;
            this.Close();
        }

        private void btnTomcat_Click(object sender, EventArgs e)
        {
            Settings.chosenPlane = 1;
            this.Close();
        }

        private void btnTigerShark_Click(object sender, EventArgs e)
        {
            Settings.chosenPlane = 0;
            this.Close();
        }
    }
}
