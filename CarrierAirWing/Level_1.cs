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

            EnemyMovement[] m = new EnemyMovement[5];
            m[0].SpeedX = -3;
            m[0].SpeedY = -3;
            m[0].steps = 30;
            m[1].SpeedX = -3;
            m[1].SpeedY = 3;
            m[1].steps = 30;
            m[2].SpeedX = -3;
            m[2].SpeedY = -3;
            m[2].steps = 30;
            m[3].SpeedX = -3;
            m[3].SpeedY = 3;
            m[3].steps = 30;
            m[4].SpeedX = 4;
            m[4].SpeedY = 0;
            m[4].steps = 90;

            Enemy e = new Enemy(700, 200, m, 0, 100);
            Enemies.AddFirst(e);

            e = new Enemy(700, 300, m, 0, 100);
            Enemies.AddFirst(e);
        }

        public override Level LevelUP()
        {
            return new Level_2();
        }
    }
}
