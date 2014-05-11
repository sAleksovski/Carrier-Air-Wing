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
            : base()
        {
            if (Settings.SOUNDS)
                SoundEngine.PlayBackgroundMusic(@"sounds\soundtracks\level1.mp3");
            Lvl = 1;
            LevelBackground = Properties.Resources.level0;
            Enemies = new LinkedList<Enemy>();

            Ticks = new LinkedList<int>();
            Ticks.AddLast(50);
            Ticks.AddLast(100);
            Ticks.AddLast(150);
            Ticks.AddLast(200);
            Ticks.AddLast(400);

            EnemyMovement[] m = new EnemyMovement[3];
            m[0].SpeedX = -3;
            m[0].SpeedY = 3;
            m[0].steps = 30;
            m[1].SpeedX = -3;
            m[1].SpeedY = 0;
            m[1].steps = 120;
            m[2].SpeedX = 3;
            m[2].SpeedY = 0;
            m[2].steps = 120;

            Enemy e = new Enemy(800, 100, m, 0, ITERATION * 20);
            Enemies.AddFirst(e);

        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(GraphicsEngine.Level1, 0 - tick % 126, 0);
            g.DrawImage(GraphicsEngine.Level1, 126 - tick % 126, 0);
            g.DrawImage(GraphicsEngine.Level1, 252 - tick % 126, 0);
            g.DrawImage(GraphicsEngine.Level1, 378 - tick % 126, 0);
            g.DrawImage(GraphicsEngine.Level1, 504 - tick % 126, 0);
            g.DrawImage(GraphicsEngine.Level1, 630 - tick % 126, 0);
            g.DrawImage(GraphicsEngine.Level1, 756 - tick % 126, 0);
            g.DrawImage(GraphicsEngine.Level1, 882 - tick % 126, 0);
        }

        public override Level LevelUP()
        {
            return new Level_2();
        }

        public override bool Tick(int enemies)
        {
            tick++;
            if (Ticks.First == null)
            {
                if(enemies == 0)
                    CanLevelUP = true;
                return false;
            }
            if (enemies == 0 || tick == Ticks.First.Value)
            {
                SetEnemies(Ticks.First.Value);
                Ticks.RemoveFirst();
                return true;
            }
            return false;
        }

        private void SetEnemies(int t)
        {
            if (t == 50 || t == 100 || t == 150 || t == 200)
            {
                Enemies = new LinkedList<Enemy>();
                EnemyMovement[] m = new EnemyMovement[3];
                m[0].SpeedX = -3;
                m[0].SpeedY = 3;
                m[0].steps = 30;
                m[1].SpeedX = -3;
                m[1].SpeedY = 0;
                m[1].steps = 120;
                m[2].SpeedX = 3;
                m[2].SpeedY = 0;
                m[2].steps = 120;

                Enemy e = new Enemy(800, 100, m, 0, ITERATION * 20);
                Enemies.AddFirst(e);           
            }
            else if (t == 400)
            {
                Enemies = new LinkedList<Enemy>();
                EnemyMovement[] m = new EnemyMovement[9];
                m[0].SpeedX = -4;
                m[0].SpeedY = 0;
                m[0].steps = 20;
                m[1].SpeedX = -4;
                m[1].SpeedY = 0;
                m[1].steps = 20;
                m[2].SpeedX = -4;
                m[2].SpeedY = 4;
                m[2].steps = 20;
                m[3].SpeedX = -4;
                m[3].SpeedY = 0;
                m[3].steps = 20;
                m[4].SpeedX = -4;
                m[4].SpeedY = 4;
                m[4].steps = 20;
                m[5].SpeedX = 4;
                m[5].SpeedY = -4;
                m[5].steps = 20;
                m[6].SpeedX = 4;
                m[6].SpeedY = 0;
                m[6].steps = 20;
                m[7].SpeedX = 4;
                m[7].SpeedY = -4;
                m[7].steps = 20;
                m[8].SpeedX = 4;
                m[8].SpeedY = 0;
                m[8].steps = 20;


                Enemy e = new Enemy(700, 100, m, 0, ITERATION * 20);
                Enemies.AddFirst(e);

                EnemyMovement[] m1 = new EnemyMovement[9];
                m1[0].SpeedX = -4;
                m1[0].SpeedY = 0;
                m1[0].steps = 20;
                m1[1].SpeedX = -4;
                m1[1].SpeedY = 0;
                m1[1].steps = 20;
                m1[2].SpeedX = -4;
                m1[2].SpeedY = -4;
                m1[2].steps = 20;
                m1[3].SpeedX = -4;
                m1[3].SpeedY = 0;
                m1[3].steps = 20;
                m1[4].SpeedX = -4;
                m1[4].SpeedY = -4;
                m1[4].steps = 20;
                m1[5].SpeedX = 4;
                m1[5].SpeedY = 4;
                m1[5].steps = 20;
                m1[6].SpeedX = 4;
                m1[6].SpeedY = 0;
                m1[6].steps = 20;
                m1[7].SpeedX = 4;
                m1[7].SpeedY = 4;
                m1[7].steps = 20;
                m1[8].SpeedX = 4;
                m1[8].SpeedY = 0;
                m1[8].steps = 20;

                e = new Enemy(700, 450, m1, 0, ITERATION * 20);
                Enemies.AddFirst(e);

                EnemyMovement[] m2 = new EnemyMovement[7];
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
                m2[6].SpeedX = -3;
                m2[6].SpeedY = 3;
                m2[6].steps = 30;

                e = new Enemy(700, 200, m2, 0, ITERATION * 20);
                Enemies.AddFirst(e);

                EnemyMovement[] m3 = new EnemyMovement[7];
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
                m3[6].SpeedX = -3;
                m3[6].SpeedY = -3;
                m3[6].steps = 30;

                e = new Enemy(700, 275, m3, 0, ITERATION * 20);
                Enemies.AddFirst(e);
            }
        }
    }
}