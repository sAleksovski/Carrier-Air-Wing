﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarrierAirWing
{
    class Level_2 : Level
    {
        public Level_2()
            : base()
        {
            Lvl = 1;
            LevelBackground = Properties.Resources.level2;
            Enemies = new LinkedList<Enemy>();

            EnemyMovement[] m = new EnemyMovement[7];
            m[0].SpeedX = -4;
            m[0].SpeedY = -4;
            m[0].steps = 20;
            m[1].SpeedX = -4;
            m[1].SpeedY = 4;
            m[1].steps = 20;
            m[2].SpeedX = -4;
            m[2].SpeedY = -4;
            m[2].steps = 20;
            m[3].SpeedX = -4;
            m[3].SpeedY = 4;
            m[3].steps = 20;
            m[4].SpeedX = -4;
            m[4].SpeedY = -4;
            m[4].steps = 20;
            m[5].SpeedX = -4;
            m[5].SpeedY = 4;
            m[5].steps = 20;
            m[6].SpeedX = 6;
            m[6].SpeedY = 0;
            m[6].steps = 80;
            EnemyMovement[] m1 = new EnemyMovement[7];
            m1[0].SpeedX = -4;
            m1[0].SpeedY = 4;
            m1[0].steps = 20;
            m1[1].SpeedX = -4;
            m1[1].SpeedY = -4;
            m1[1].steps = 20;
            m1[2].SpeedX = -4;
            m1[2].SpeedY = 4;
            m1[2].steps = 20;
            m1[3].SpeedX = -4;
            m1[3].SpeedY = -4;
            m1[3].steps = 20;
            m1[4].SpeedX = -4;
            m1[4].SpeedY = 4;
            m1[4].steps = 20;
            m1[5].SpeedX = -4;
            m1[5].SpeedY = -4;
            m1[5].steps = 20;
            m1[6].SpeedX = 6;
            m1[6].SpeedY = 0;
            m1[6].steps = 80;
            EnemyMovement[] m2 = new EnemyMovement[6];
            m2[0].SpeedX = -3;
            m2[0].SpeedY = 3;
            m2[0].steps = 30;
            m2[1].SpeedX = -3;
            m2[1].SpeedY = -3;
            m2[1].steps = 30;
            m2[2].SpeedX = -3;
            m2[2].SpeedY = 3;
            m2[2].steps = 30;
            m2[3].SpeedX = 3;
            m2[3].SpeedY = -3;
            m2[3].steps = 30;
            m2[4].SpeedX = 3;
            m2[4].SpeedY = 3;
            m2[4].steps = 30;
            m2[5].SpeedX = 3;
            m2[5].SpeedY = -3;
            m2[5].steps = 30;
            EnemyMovement[] m3 = new EnemyMovement[6];
            m3[0].SpeedX = -3;
            m3[0].SpeedY = -3;
            m3[0].steps = 30;
            m3[1].SpeedX = -3;
            m3[1].SpeedY = 3;
            m3[1].steps = 30;
            m3[2].SpeedX = -3;
            m3[2].SpeedY = -3;
            m3[2].steps = 30;
            m3[3].SpeedX = 3;
            m3[3].SpeedY = 3;
            m3[3].steps = 30;
            m3[4].SpeedX = 3;
            m3[4].SpeedY = -3;
            m3[4].steps = 30;
            m3[5].SpeedX = 3;
            m3[5].SpeedY = 3;
            m3[5].steps = 30;
            Enemy e = new Enemy(700, 100, m, 0, 150);
            Enemies.AddFirst(e);
            e = new Enemy(700, 200, m3, 0, 150);
            Enemies.AddFirst(e);
            e = new Enemy(700, 275, m2, 0, 150);
            Enemies.AddFirst(e);
            e = new Enemy(700, 450, m1, 0, 150);
            Enemies.AddFirst(e);

        }

        public override Level LevelUP()
        {
            return null;
        }
    }
}
