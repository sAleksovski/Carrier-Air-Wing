using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WarPlanes
{
    public partial class Form1 : Form
    {
        public static int FRAMES_PER_SECOND = 60;
        public Game game;
        public Timer timer;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            game = new Game();
            timer = new Timer();
            timer.Interval = 1000 / FRAMES_PER_SECOND;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            game.Move();
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                game.Fire(game.p1);
            if (e.KeyCode == Keys.Up)
                game.p1.plane.PM.UP = true;
            else if (e.KeyCode == Keys.Down)
                game.p1.plane.PM.DOWN = true;
            if (e.KeyCode == Keys.Left)
                game.p1.plane.PM.LEFT = true;
            else if (e.KeyCode == Keys.Right)
                game.p1.plane.PM.RIGHT = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                game.p1.plane.PM.UP = false;
            else if (e.KeyCode == Keys.Down)
                game.p1.plane.PM.DOWN = false;
            if (e.KeyCode == Keys.Left)
                game.p1.plane.PM.LEFT = false;
            else if (e.KeyCode == Keys.Right)
                game.p1.plane.PM.RIGHT = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            game.Draw(g);
        }
    }
}
