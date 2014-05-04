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
            Point l = new Point(900, -100);
            Point[] m = new Point[4];
            m[0] = new Point(700, 100);
            m[1] = new Point(700, 500);
            m[2] = new Point(300, 500);
            m[3] = new Point(700, 100);
            Enemy e = new Enemy(l, m);
            Enemies.Add(e);
            Point l1 = new Point(700, 500);
            Point[] m1 = new Point[4];
            m1[0] = new Point(100, 100);
            m1[1] = new Point(300, 600);
            m1[2] = new Point(755, 200);
            m1[3] = new Point(312, 400);
            Enemy e1 = new Enemy(l1, m1);
            Enemies.Add(e1);
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
