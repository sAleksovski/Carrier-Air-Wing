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
        public LinkedList<int> Ticks;
        public int tick;
        public bool CanLevelUP;
        public static int ITERATION = 1;

        public Level()
        {
            tick = 0;
            CanLevelUP = false;
        }

        public abstract void Draw(Graphics g);

        public abstract Level LevelUP();
        public abstract bool Tick(int enemies);
    }
}
