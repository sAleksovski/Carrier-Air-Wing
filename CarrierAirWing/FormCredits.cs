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
    public partial class FormCredits : Form
    {
        public List<string> creators;
        public Bitmap plane1;
        public Bitmap plane2;
        public Bitmap plane3;

        public int p1X;
        public int p2X;
        public int p3X;

        public Timer timer;

        public FormCredits()
        {
            InitializeComponent();
            DoubleBuffered = true;
            creators = new List<string>();
            creators.Add("Stefan Aleksovski");
            creators.Add("Vladica Jovanovski");
            creators.Add("Martin Milutinovikj");

            Random rnd = new Random();
            var acreators = creators.OrderBy(item => rnd.Next());

            creators = new List<string>();
            foreach (var item in acreators)
            {
                creators.Add(item);
            }

            plane1 = GraphicsEngine.planeSprites[0][0];
            plane2 = GraphicsEngine.enemySprites[11][0];
            plane3 = GraphicsEngine.planeSprites[2][0];

            p1X = -300;
            p2X = this.Width + 200;
            p3X = -350;

            timer = new Timer();
            timer.Interval = 25;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
            p1X += 3;
            if (p1X > this.Width + plane1.Width + 150)
                p1X = -plane1.Width;
            p2X -= 3;
            if (p2X < 0 - plane2.Width - 250)
                p2X = this.Width + 30;
            p3X += 3;
            if (p3X > this.Width + plane3.Width + 150)
                p3X = -plane3.Width;
        }

        private void FormCredits_Load(object sender, EventArgs e)
        {
            if (Settings.SOUNDS)
                SoundEngine.PlayBackgroundMusic(@"sounds\soundtracks\credits.mp3");
        }

        private void FormCredits_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Settings.SOUNDS)
                SoundEngine.PlayBackgroundMusic(@"sounds\soundtracks\menu.mp3");
        }

        private void FormCredits_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);
            g.DrawImage(plane1, p1X, 60);
            g.DrawLine(new Pen(Color.White), p1X - 40, 60 + plane1.Height / 2, p1X, 60 + plane1.Height / 2);
            g.DrawString(creators[0], new Font(FontFamily.GenericMonospace, 12), new SolidBrush(Color.White), p1X - 10 - creators[0].Length * 12, 60);

            g.DrawImage(plane2, p2X, 120);
            g.DrawLine(new Pen(Color.White), p2X + plane2.Width + 5, 120 + plane2.Height / 2, p2X + plane2.Width + 5 + 40, 120 + plane2.Height / 2);
            g.DrawString(creators[1], new Font(FontFamily.GenericMonospace, 12), new SolidBrush(Color.White), p2X + plane2.Width + 40 + 10, 120);

            g.DrawImage(plane3, p3X, 180);
            g.DrawLine(new Pen(Color.White), p3X - 40, 180 + plane3.Height / 2, p3X, 180 + plane3.Height / 2);
            g.DrawString(creators[2], new Font(FontFamily.GenericMonospace, 12), new SolidBrush(Color.White), p3X - 10 - creators[2].Length * 12, 180);
        }
    }
}
