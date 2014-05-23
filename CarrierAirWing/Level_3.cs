using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CarrierAirWing
{
    class Level_3 : Level
    {
        private int t; 
        private bool forward;

        public Level_3()
        {
            if (Settings.SOUNDS)
                SoundEngine.PlayBackgroundMusic(@"sounds\soundtracks\level3.mp3");
            Lvl = 3;
            t = 1;
            forward = true;
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
            // avioncinja levo
            for (int i = 0; i < 3; i++)
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -8;
                m[0].SpeedY = 0;
                m[0].steps = 150;
                Enemy e = new Enemy(740, 200 + i * 3, m, ITERATION * 20, 19, 100);
                Enemies.AddLast(new EnemyWrapper(e, 50 + i * 15));
            }

            // avioncinja levo 2
            for (int i = 0; i < 4; i++)
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -8;
                m[0].SpeedY = 1;
                m[0].steps = 150;
                Enemy e = new Enemy(740, 200 + i * 3, m, ITERATION * 20, 8, 100);
                Enemies.AddLast(new EnemyWrapper(e, 200 + i * 20));
            }

            // heli crveni od desno
            for (int i = 0; i < 3; i++)
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -4;
                m[0].SpeedY = 1;
                m[0].steps = 220;
                Enemy e = new Enemy(740, 100 + i * 30, m, ITERATION * 20, 6, 100);
                Enemies.AddLast(new EnemyWrapper(e, 320 + i * 40));
            }


            // zaebani avioncinja
            for (int i = 0; i < 2; i++)
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
                Enemy e = new Enemy(740, 150 + i * 100, m, ITERATION * 20 + 500, 22, 80);
                Enemies.AddLast(new EnemyWrapper(e, 320 + i * 30));
            }


            // Heli od desno
            for (int i = 0; i < 4; i++)
            {
                EnemyMovement[] m = new EnemyMovement[3];
                m[0].SpeedX = -4;
                m[0].SpeedY = 0;
                m[0].steps = 25;
                m[1].SpeedX = -3;
                m[1].SpeedY = +6;
                m[1].steps = 5;
                m[2].SpeedX = -4;
                m[2].SpeedY = 0;
                m[2].steps = 200;
                Enemy e = new Enemy(740, 100 + i * 10, m, ITERATION * 20, (i % 2 == 0) ? 2 : 6, 150);
                Enemies.AddLast(new EnemyWrapper(e, 600 + i * 25));
            }



            // Heli na pocetak od levo
            for (int i = 0; i < 4; i++)
            {
                EnemyMovement[] m = new EnemyMovement[3];
                m[0].SpeedX = +4;
                m[0].SpeedY = 3;
                m[0].steps = 25;
                m[1].SpeedX = +3;
                m[1].SpeedY = -6;
                m[1].steps = 5;
                m[2].SpeedX = +4;
                m[2].SpeedY = 0;
                m[2].steps = 200;
                Enemy e = new Enemy(0, 300 + i * 3, m, ITERATION * 20, (i % 2 == 0) ? 2 : 6, 150);
                Enemies.AddLast(new EnemyWrapper(e, 600 + i * 25));
            }

            // Plavi avioncinja diagonala
            for (int i = 0; i < 13; i++)
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -8;
                m[0].SpeedY = 1;
                m[0].steps = 150;
                Enemy e = new Enemy(740, 50 + i *  22, m, ITERATION * 20, 8, 100);
                Enemies.AddLast(new EnemyWrapper(e, 850 + i * 5));
            }


            // Heli od desno
            for (int i = 0; i < 4; i++)
            {
                EnemyMovement[] m = new EnemyMovement[3];
                m[0].SpeedX = -4;
                m[0].SpeedY = 0;
                m[0].steps = 25;
                m[1].SpeedX = -3;
                m[1].SpeedY = +6;
                m[1].steps = 5;
                m[2].SpeedX = -4;
                m[2].SpeedY = 0;
                m[2].steps = 200;
                Enemy e = new Enemy(740, 100 + i * 10, m, ITERATION * 20, (i % 2 == 0) ? 0 : 4, 150);
                Enemies.AddLast(new EnemyWrapper(e, 920 + i * 25));
            }


            // Heli od desno
            for (int i = 0; i < 4; i++)
            {
                EnemyMovement[] m = new EnemyMovement[3];
                m[0].SpeedX = -4;
                m[0].SpeedY = 0;
                m[0].steps = 25;
                m[1].SpeedX = -3;
                m[1].SpeedY = +6;
                m[1].steps = 5;
                m[2].SpeedX = -4;
                m[2].SpeedY = 0;
                m[2].steps = 200;
                Enemy e = new Enemy(740, 10 + i * 35, m, ITERATION * 20, (i % 2 == 0) ? 0 : 4, 150);
                Enemies.AddLast(new EnemyWrapper(e, 1200 + i * 25));
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
                Enemies.AddLast(new EnemyWrapper(e, 1500 + i * 25));
                Enemies.AddLast(new EnemyWrapper(e1, 1500 + i * 25));
            }

            for (int i = 0; i < 5; i++)
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -10;
                m[0].SpeedY = 0;
                m[0].steps = 100;
                Enemy e = new Enemy(740, 200 + i * 20, m, ITERATION * 20, (i % 2 == 0) ? 8 : 11, 50);
                Enemies.AddLast(new EnemyWrapper(e, 1600 + i * 150));
            }


            // Avionoi krst
            for (int i = 0; i < 5; i++)
            {
                EnemyMovement[] m = new EnemyMovement[2];
                m[0].SpeedX = -4;
                m[0].SpeedY = 4;
                m[0].steps = 30;
                m[1].SpeedX = -8;
                m[1].SpeedY = -8;
                m[1].steps = 150;

                EnemyMovement[] m1 = new EnemyMovement[2];
                m1[0].SpeedX = -4;
                m1[0].SpeedY = -4;
                m1[0].steps = 25;
                m1[1].SpeedX = -8;
                m1[1].SpeedY = 8;
                m1[1].steps = 150;

                Enemy e = new Enemy(740, 200 + i * 2, m, ITERATION * 20, 18, 20);
                Enemy e1 = new Enemy(740, 250 + i * 2, m1, ITERATION * 20, 12, 20);
                Enemies.AddLast(new EnemyWrapper(e, 1800 + i * 25));
                Enemies.AddLast(new EnemyWrapper(e1, 1800 + i * 25));
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

            // nesto
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
                Enemies.AddLast(new EnemyWrapper(e, 2000 + i * 25));
                Enemies.AddLast(new EnemyWrapper(e1, 2000 + i * 25));
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
                Enemies.AddLast(new EnemyWrapper(e1, 2200 + i * 30));
            }


            // Zeleno heli
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = 4;
                m[0].SpeedY = 0;
                m[0].steps = 250;
                Enemy e = new Enemy(0, 400, m, ITERATION * 20, 2, 100);
                Enemies.AddLast(new EnemyWrapper(e, 2000));
            }

            // Crveno heli
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -4;
                m[0].SpeedY = 0;
                m[0].steps = 250;
                Enemy e = new Enemy(740, 50, m, ITERATION * 20, 4, 200);
                Enemies.AddLast(new EnemyWrapper(e, 2100));
            }

            // Crveno heli
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -3;
                m[0].SpeedY = 0;
                m[0].steps = 400;
                Enemy e = new Enemy(740, 400, m, ITERATION * 20, 5, 200);
                Enemies.AddLast(new EnemyWrapper(e, 2200));
            }

            // Nesto

            for (int i = 0; i < 5; i++)
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -5;
                m[0].SpeedY = 0;
                m[0].steps = 300;
                Enemy e = new Enemy(740, 200 + i * 10, m, ITERATION * 20, 9, 100);
                Enemies.AddLast(new EnemyWrapper(e, 2200 + i * 60));
            }


            for (int i = 0; i < 5; i++)
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -5;
                m[0].SpeedY = 0;
                m[0].steps = 200;
                Enemy e = new Enemy(740, 10 + i * 80, m, ITERATION * 20, 12, 100);
                Enemies.AddLast(new EnemyWrapper(e, 2100 + i * 45));
            }


            for (int i = 0; i < 15; i++)
            {
                EnemyMovement[] m = new EnemyMovement[1];
                m[0].SpeedX = -5;
                m[0].SpeedY = 0;
                m[0].steps = 200;
                Enemy e = new Enemy(740, 10 + i * 30, m, ITERATION * 20, 18, 100);
                Enemies.AddLast(new EnemyWrapper(e, 210 + i * 100));
            }

        }

        public override Level LevelUP()
        {
            ITERATION++;
            return new Level_1();
        }

        public override void Tick()
        {
            Ticks++;
            if (Enemies.Count == 0)
                CanLevelUP = true;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(GraphicsEngine.Level3[t], 0, 0);
            if (forward) 
            { 
                t++; 
                if (t == 5) 
                { 
                    forward = false; t = 4; 
                } 
            } 
            else { 
                t--; 
                if (t == -1) 
                { 
                    forward = true; t = 0; 
                } 
            }
        }


    }
}
