using CarrierAirWing.Properties;
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
        private Form gameForm;
        private Form choosePlaneForm;
        private Form highScore;
        private Form creditsForm;

        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            gameForm = new FormGame(this);
            gameForm.Show();
            this.Hide();
        }

        private void btnChoosePlane_Click(object sender, EventArgs e)
        {
            choosePlaneForm = new FormChoosePlane();
            choosePlaneForm.ShowDialog();
        }

        private void btnHighScore_Click(object sender, EventArgs e)
        {
            highScore = new FormHighScore();
            highScore.ShowDialog();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            GraphicsEngine.Init();
            SoundEngine.Init();
            Settings.Init();

            if (Settings.SOUNDS)
                SoundEngine.PlayBackgroundMusic(@"sounds\soundtracks\menu.mp3");
        }

        private void FormMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.WriteHighScore();
        }

        private void FormMenu_Shown(object sender, EventArgs e)
        {
            
        }

        private void FormMenu_Activated(object sender, EventArgs e)
        {
            if (gameForm != null)
                gameForm.Dispose();

            if (choosePlaneForm != null)
                choosePlaneForm.Dispose();

            if (highScore != null)
                highScore.Dispose();

            gameForm = null;
            choosePlaneForm = null;
            highScore = null;
        }

        private void btnCredits_Click(object sender, EventArgs e)
        {
            creditsForm = new FormCredits();
            creditsForm.ShowDialog();
        }
    }
}
