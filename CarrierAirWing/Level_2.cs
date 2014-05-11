using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CarrierAirWing
{
    class Level_2 : Level
    {
        public Level_2()
        {
            if (Settings.SOUNDS)
                SoundEngine.PlayBackgroundMusic(@"sounds\soundtracks\level2.mp3");
            Lvl = 2;
            LevelBackground = Properties.Resources.level2;
            AddEnemies();
        }

        private void AddEnemies()
        {
            // Heli na pocetak od levo
            for (int i = 0; i < 4; i++)
            {
                EnemyMovement[] m = new EnemyMovement[3];
                m[0].SpeedX = +4;
                m[0].SpeedY = 0;
                m[0].steps = 25;
                m[1].SpeedX = +3;
                m[1].SpeedY = +6;
                m[1].steps = 5;
                m[2].SpeedX = +4;
                m[2].SpeedY = 0;
                m[2].steps = 400;
                Enemy e = new Enemy(0, 100 + i * 3, m, ITERATION * 20, (i % 2 == 0 ) ? 2 : 6 , 150);
                Enemies.AddLast(new EnemyWrapper(e, 50 + i * 25));
            }


            // Heli od desno
            for (int i = 0; i < 8; i++)
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -6;
                m[0].SpeedY = 1;
                m[0].steps = 100;
                Enemy e = new Enemy(740, 200 + i * 2, m, ITERATION * 20, (i % 2 == 0) ? 1 : 5, 150);
                Enemies.AddLast(new EnemyWrapper(e, 210 + i * 40));
            }

            // Ne se sekam ni ja
            for (int i = 0; i < 3; i++)
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -8;
                m[0].SpeedY = 0;
                m[0].steps = 150;
                Enemy e = new Enemy(740, 200 + i * 2, m, ITERATION * 20, 18, 50);
                Enemies.AddLast(new EnemyWrapper(e, 540 + i * 30));
            }

            // Puno heli od desno
            for (int i = 0; i < 3; i++)
            {
                EnemyMovement[] m = new EnemyMovement[2];
                m[0].SpeedX = -4;
                m[0].SpeedY = 1;
                m[0].steps = 20;
                m[1].SpeedX = -4;
                m[1].SpeedY = 0;
                m[1].steps = 150;
                Enemy e = new Enemy(740, 200 + i * 2, m, ITERATION * 20, 0, 50);
                Enemy e1 = new Enemy(740, 250 + i * 2, m, ITERATION * 20, 6, 50);
                Enemies.AddLast(new EnemyWrapper(e, 620 + i * 25));
                Enemies.AddLast(new EnemyWrapper(e1, 620 + i * 25));
            }

            // Avionoi krst
            for (int i = 0; i < 5; i++)
            {
                EnemyMovement[] m = new EnemyMovement[2];
                m[0].SpeedX = -4;
                m[0].SpeedY = 4;
                m[0].steps = 30;
                m[1].SpeedX = -8;
                m[1].SpeedY = -5;
                m[1].steps = 150;

                EnemyMovement[] m1 = new EnemyMovement[2];
                m1[0].SpeedX = -4;
                m1[0].SpeedY = -4;
                m1[0].steps = 25;
                m1[1].SpeedX = -8;
                m1[1].SpeedY = 5;
                m1[1].steps = 150;

                Enemy e = new Enemy(740, 200 + i * 2, m, ITERATION * 20, 18, 20);
                Enemy e1 = new Enemy(740, 250 + i * 2, m1, ITERATION * 20, 12, 20);
                Enemies.AddLast(new EnemyWrapper(e, 800 + i * 25));
                Enemies.AddLast(new EnemyWrapper(e1, 800 + i * 25));
            }


            for (int i = 0; i < 3; i++)
            {
                EnemyMovement[] m = new EnemyMovement[2];
                m[0].SpeedX = +4;
                m[0].SpeedY = 1;
                m[0].steps = 20;
                m[1].SpeedX = 6;
                m[1].SpeedY = 0;
                m[1].steps = 150;
                EnemyMovement[] m1 = new EnemyMovement[2];
                m1[0].SpeedX = +4;
                m1[0].SpeedY = -1;
                m1[0].steps = 20;
                m1[1].SpeedX = 4;
                m1[1].SpeedY = 0;
                m1[1].steps = 150;
                Enemy e = new Enemy(0, 100 + i * 2, m, ITERATION * 20, (i % 2 == 0) ? 2 : 6, 50);
                Enemy e1 = new Enemy(0, 300 + i * 2, m1, ITERATION * 20, (i % 2 == 0) ? 7 : 3, 50);
                Enemies.AddLast(new EnemyWrapper(e, 990 + i * 25));
                Enemies.AddLast(new EnemyWrapper(e1, 990 + i * 25));
            }


            // Zaebani avioni
            for (int i = 0; i < 2; i++)
            {
                EnemyMovement[] m = new EnemyMovement[2];
                m[0].SpeedX = +4;
                m[0].SpeedY = 1;
                m[0].steps = 20;
                m[1].SpeedX = 6;
                m[1].SpeedY = 0;
                m[1].steps = 150;

                EnemyMovement[] m1 = new EnemyMovement[6];
                m1[0].SpeedX = -2;
                m1[0].SpeedY = -1;
                m1[0].steps = 30;
                m1[1].SpeedX = -2;
                m1[1].SpeedY = 0;
                m1[1].steps = 40;
                m1[2].SpeedX = -3;
                m1[2].SpeedY = 0;
                m1[2].steps = 60;
                m1[3].SpeedX = 3;
                m1[3].SpeedY = -2;
                m1[3].steps = 60;
                m1[4].SpeedX = -3;
                m1[4].SpeedY = -2;
                m1[4].steps = 60;
                m1[5].SpeedX = 1;
                m1[5].SpeedY = 1;
                m1[5].steps = 100;

                Enemy e = new Enemy(0, 100 + i * 20, m, ITERATION * 20, 16, 50);
                Enemy e1 = new Enemy(740, 250 + i * 30, m1, 200 + ITERATION * 20, 22, 40);
                Enemies.AddLast(new EnemyWrapper(e, 1200 + i * 25));
                Enemies.AddLast(new EnemyWrapper(e1, 1200 + i * 100));
            }


            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = +8;
                m[0].SpeedY = 0;
                m[0].steps = 150;
                Enemy e = new Enemy(0, 100, m, ITERATION * 20, 10, 100);
                Enemies.AddLast(new EnemyWrapper(e, 200));
            }

            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = +8;
                m[0].SpeedY = 0;
                m[0].steps = 150;
                Enemy e = new Enemy(0, 400, m, ITERATION * 20, 10, 100);
                Enemies.AddLast(new EnemyWrapper(e, 400));
            }

            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -8;
                m[0].SpeedY = 0;
                m[0].steps = 150;
                Enemy e = new Enemy(740, 400, m, ITERATION * 20, 11, 100);
                Enemies.AddLast(new EnemyWrapper(e, 800));
            }

            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -8;
                m[0].SpeedY = 0;
                m[0].steps = 150;
                Enemy e = new Enemy(740, 230, m, ITERATION * 20, 11, 100);
                Enemies.AddLast(new EnemyWrapper(e, 900));
            }

            // Zeleno heli
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = 4;
                m[0].SpeedY = 0;
                m[0].steps = 250;
                Enemy e = new Enemy(0, 230, m, ITERATION * 20, 3, 100);
                Enemies.AddLast(new EnemyWrapper(e, 1000));
            }

            // Zeleno heli
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = 4;
                m[0].SpeedY = 0;
                m[0].steps = 250;
                Enemy e = new Enemy(0, 400, m, ITERATION * 20, 2, 100);
                Enemies.AddLast(new EnemyWrapper(e, 1500));
            }

            // Crveno heli
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -4;
                m[0].SpeedY = 0;
                m[0].steps = 250;
                Enemy e = new Enemy(740, 50, m, ITERATION * 20, 4, 200);
                Enemies.AddLast(new EnemyWrapper(e, 1000));
            }

            // Crveno heli
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -3;
                m[0].SpeedY = 0;
                m[0].steps = 400;
                Enemy e = new Enemy(740, 400, m, ITERATION * 20, 5, 200);
                Enemies.AddLast(new EnemyWrapper(e, 1700));
            }

            // Crveno heli
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -4;
                m[0].SpeedY = 0;
                m[0].steps = 250;
                Enemy e = new Enemy(740, 400, m, ITERATION * 20, 4, 200);
                Enemies.AddLast(new EnemyWrapper(e, 1200));
            }

            // Zaebani avioni
            for (int i = 0; i < 4; i++)
            {
                EnemyMovement[] m1 = new EnemyMovement[6];
                m1[0].SpeedX = -2;
                m1[0].SpeedY = -1;
                m1[0].steps = 30;
                m1[1].SpeedX = -2;
                m1[1].SpeedY = 0;
                m1[1].steps = 40;
                m1[2].SpeedX = -3;
                m1[2].SpeedY = 0;
                m1[2].steps = 60;
                m1[3].SpeedX = 3;
                m1[3].SpeedY = -2;
                m1[3].steps = 60;
                m1[4].SpeedX = -3;
                m1[4].SpeedY = -2;
                m1[4].steps = 60;
                m1[5].SpeedX = 1;
                m1[5].SpeedY = 1;
                m1[5].steps = 100;
                Enemy e1 = new Enemy(740, 250 + i * 44, m1, 300 + ITERATION * 20, 22, 40);
                Enemies.AddLast(new EnemyWrapper(e1, 1500 + i * 30));
            }

        }

        public override Level LevelUP()
        {
            return new Level_3();
        }

        public override void Tick()
        {
            Ticks++;
            if (Enemies.Count == 0)
                CanLevelUP = true;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(GraphicsEngine.Level2, 0 - Ticks % 127, 0);
            g.DrawImage(GraphicsEngine.Level2, 127 - Ticks % 127, 0);
            g.DrawImage(GraphicsEngine.Level2, 254 - Ticks % 127, 0);
            g.DrawImage(GraphicsEngine.Level2, 381 - Ticks % 127, 0);
            g.DrawImage(GraphicsEngine.Level2, 508 - Ticks % 127, 0);
            g.DrawImage(GraphicsEngine.Level2, 635 - Ticks % 127, 0);
            g.DrawImage(GraphicsEngine.Level2, 762 - Ticks % 127, 0);
            g.DrawImage(GraphicsEngine.Level2, 889 - Ticks % 127, 0);
        }


    }
}
