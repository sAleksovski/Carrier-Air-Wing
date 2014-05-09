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
    public partial class FormHighScore : Form
    {
        public Label[] labels;
        public FormHighScore()
        {
            InitializeComponent();
            labels = new Label[10];
            labels[0] = label1;
            labels[1] = label2;
            labels[2] = label3;
            labels[3] = label4;
            labels[4] = label5;
            labels[5] = label6;
            labels[6] = label7;
            labels[7] = label8;
            labels[8] = label9;
            labels[9] = label10;

            for (int i = 0; i < 10; i++)
                labels[i].Text = "";

            for (int i = 0; i < Settings.highScores.scores.Count; i++)
                labels[i].Text = (i+1).ToString() + ". " + Settings.highScores.scores[i].ToString();

        }
    }
}
