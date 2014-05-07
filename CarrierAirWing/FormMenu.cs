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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Form f = new FormGame(this);
            f.Show();
            this.Hide();
        }

        private void btnChoosePlane_Click(object sender, EventArgs e)
        {
            Form f = new FormChoosePlane();
            f.ShowDialog();
        }

        private void btnHighScore_Click(object sender, EventArgs e)
        {
            Form f = new FormHighScore();
            f.ShowDialog();
        }
    }
}
