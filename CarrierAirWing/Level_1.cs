using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CarrierAirWing
{
    class Level_1 : Level
    {
        public Level_1()
        {
            if (Settings.SOUNDS)
                SoundEngine.PlayBackgroundMusic(@"sounds\soundtracks\level1.mp3");
            Lvl = 1;
            LevelBackground = Properties.Resources.level0;
            AddEnemies();

            // Sort all enemies by tick value
            List<EnemyWrapper> temp = Enemies.ToList();
            temp.Sort(
                    delegate(EnemyWrapper ew1, EnemyWrapper ew2)
                    {
                        return ew1.Ticks.CompareTo(ew2.Ticks);
                    }
                );
            Enemies.Clear();

            // Add them back to LinkedList
            foreach (EnemyWrapper ew in temp)
                Enemies.AddLast(ew);
            temp.Clear();
        }

        private void AddEnemies()
        {
            for (int i = 0; i < 10; i++)
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -4;
                m[0].SpeedY = 1;
                m[0].steps = 100;
                Enemy e = new Enemy(740, 200 + i * 3, m, ITERATION * 20, 1, 200);
                Enemies.AddLast(new EnemyWrapper(e, 50 + i * 40));
            }

            for (int i = 0; i < 10; i++)
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -5;
                m[0].SpeedY = -2;
                m[0].steps = 100;
                Enemy e = new Enemy(740, 400 + i * 3, m, ITERATION * 20, 5, 200);
                Enemies.AddLast(new EnemyWrapper(e, 500 + i * 40));
            }

            for (int i = 0; i < 5; i++)
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -10;
                m[0].SpeedY = 0;
                m[0].steps = 100;
                Enemy e = new Enemy(740, 200 + i * 20, m, ITERATION * 20, (i % 2 == 0) ? 8 : 11, 50);
                Enemies.AddLast(new EnemyWrapper(e, 1050 + i * 150));
            }

            for (int i = 0; i < 5; i++)
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -5;
                m[0].SpeedY = 0;
                m[0].steps = 300;
                Enemy e = new Enemy(740, 200 + i * 10, m, ITERATION * 20, 9, 100);
                Enemies.AddLast(new EnemyWrapper(e, 500 + i * 165));
            }

            for (int i = 0; i < 10; i++)
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -5;
                m[0].SpeedY = 0;
                m[0].steps = 300;
                Enemy e = new Enemy(740, 200 + i * 10, m, ITERATION * 20, 2, 100);
                Enemies.AddLast(new EnemyWrapper(e, 70 + i * 200));
            }


            for (int i = 0; i < 5; i++)
            {
                EnemyMovement[] m = new EnemyMovement[3];
                m[0].SpeedX = -5;
                m[0].SpeedY = 0;
                m[0].steps = 200;
                m[1].SpeedX = 5;
                m[1].SpeedY = +1;
                m[1].steps = 200;
                m[2].SpeedX = -5;
                m[2].SpeedY = -1;
                m[2].steps = 200;
                Enemy e = new Enemy(740, 150 + i * 50, m, ITERATION * 20 + 200, 22, 80);
                Enemies.AddLast(new EnemyWrapper(e, 2000 + i * 45));
            }


            for (int i = 0; i < 1; i++)
            {
                EnemyMovement[] m = new EnemyMovement[4];
                m[0].SpeedX = -3;
                m[0].SpeedY = 3;
                m[0].steps = 35;

                m[1].SpeedX = -3;
                m[1].SpeedY = -3;
                m[1].steps = 35;

                m[2].SpeedX = +3;
                m[2].SpeedY = -3;
                m[2].steps = 25;

                m[3].SpeedX = 3;
                m[3].SpeedY = +3;
                m[3].steps = 25;
                Enemy e = new Boss(740, 150, m, ITERATION * 20 + 1000, 23, 100);
                Enemies.AddLast(new EnemyWrapper(e, 2550 ));
            }
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(GraphicsEngine.Level1, 0 - Ticks % 126, 0);
            g.DrawImage(GraphicsEngine.Level1, 126 - Ticks % 126, 0);
            g.DrawImage(GraphicsEngine.Level1, 252 - Ticks % 126, 0);
            g.DrawImage(GraphicsEngine.Level1, 378 - Ticks % 126, 0);
            g.DrawImage(GraphicsEngine.Level1, 504 - Ticks % 126, 0);
            g.DrawImage(GraphicsEngine.Level1, 630 - Ticks % 126, 0);
            g.DrawImage(GraphicsEngine.Level1, 756 - Ticks % 126, 0);
            g.DrawImage(GraphicsEngine.Level1, 882 - Ticks % 126, 0);
        }

        public override Level LevelUP()
        {
            return new Level_2();
        }

        public override void Tick()
        {
            Ticks++;
            if (Enemies.Count == 0)
                CanLevelUP = true;
        }

    }
}