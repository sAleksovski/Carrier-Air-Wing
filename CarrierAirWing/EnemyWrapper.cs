using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarrierAirWing
{
    public class EnemyWrapper
    {
        public Enemy EnemyPlane { get; set; }
        public int Ticks { get; set; }

        public EnemyWrapper(Enemy enemy, int ticks)
        {
            EnemyPlane = enemy;
            Ticks = ticks;
        }
    }
}
