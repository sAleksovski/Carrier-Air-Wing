using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CarrierAirWing
{
    public class Level
    {
        public int Lvl;
        public Image LevelBackground;

        public Level()
        {
            LevelBackground = Properties.Resources.level0;
        }

        public Level(int n)
        {
            LevelBackground = Properties.Resources.level1;
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
