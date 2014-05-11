using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CarrierAirWing
{
    public abstract class Level
    {
        public int Lvl { get; set; }
        public Image LevelBackground { get; set; }
        public LinkedList<EnemyWrapper> Enemies { get; set; }
        public int Ticks { get; set; }
        public bool CanLevelUP { get; set; }
        public static int ITERATION = 1;

        public Level()
        {
            Ticks = 0;
            CanLevelUP = false;
            Enemies = new LinkedList<EnemyWrapper>();
        }

        public abstract Level LevelUP();
        public abstract void Tick();
        public abstract void Draw(Graphics g);
    }
}
