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
            Enemies = new List<Enemy>();
            ScoreToLevelUp = 100;
            Lvl = 0;
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
