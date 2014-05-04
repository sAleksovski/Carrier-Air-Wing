using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WarPlanes
{
    public class Level
    {
        public int Lvl;
        public int ScoreToLevelUp;
        public Image LevelBackground;
        public List<Enemy> Enemies;

        public Level()
        {
            LevelBackground = Properties.Resources.level0;
            ScoreToLevelUp = 100;
            Lvl = 0;
            Enemies = new List<Enemy>();
            Point l = new Point(700, 100);
            Point[] m = new Point[4];
            m[0] = new Point(700, 100);
            m[1] = new Point(400, 300);
            m[2] = new Point(300, 250);
            m[3] = new Point(100, 400);
            Enemy e = new Enemy(l, m);
            Enemies.Add(e);
        }

        public Level(int n)
        {
            LevelBackground = Properties.Resources.level1;
            Enemies = new List<Enemy>();
            ScoreToLevelUp = 200;
            Lvl = n;
        }

        public void Draw(Graphics g)
        {
            g.DrawImageUnscaled(LevelBackground, 0, 0);
        }

        public Level LevelUP()
        {
            return new Level(1);
        }
    }
}
