using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CarrierAirWing
{
    public abstract class Level
    {
        public int Lvl;
        public Image LevelBackground;
        public LinkedList<Enemy> Enemies;

        public Level()
        {

        }

        public void Draw(Graphics g)
        {
            g.DrawImageUnscaled(LevelBackground, 0, 0); // Neshto da se dvizi?
        }

        public abstract Level LevelUP();
    }
}
