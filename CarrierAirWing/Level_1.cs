using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarrierAirWing
{
    class Level_1 : Level
    {
        public Level_1()
            : base()
        {
            Lvl = 1;
            LevelBackground = Properties.Resources.level0;
            Enemies = new LinkedList<Enemy>();

            EnemyMovement[] m = new EnemyMovement[4];
            m[0].SpeedX = -5;
            m[0].SpeedY = 0;
            m[0].steps = 20;
            m[1].SpeedX = 0;
            m[1].SpeedY = -5;
            m[1].steps = 20;
            m[2].SpeedX = 5;
            m[2].SpeedY = 0;
            m[2].steps = 20;
            m[3].SpeedX = 0;
            m[3].SpeedY = 5;
            m[3].steps = 20;

            Enemy e = new Enemy(500, 250, m, 0);

            Enemies.AddFirst(e);
        }

        public override Level LevelUP()
        {
            return new Level_2();
        }
    }
}
