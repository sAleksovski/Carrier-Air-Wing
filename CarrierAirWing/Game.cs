using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CarrierAirWing
{
    public struct Controls
    {
        public System.Windows.Forms.Keys UP;
        public System.Windows.Forms.Keys DOWN;
        public System.Windows.Forms.Keys LEFT;
        public System.Windows.Forms.Keys RIGHT;
        public System.Windows.Forms.Keys A;
        public System.Windows.Forms.Keys B;
    };

    public class Game
    {
        public Level level;
        public Player p1;
        public Controls p1Controls;
        public LinkedList<Enemy> enemies;
        public LinkedList<Bullet> playerBullets;
        public LinkedList<Rocket> playerRockets;
        public LinkedList<Bullet> enemyBullets;
        public int BoundsX { get; set; }
        public int BoundsY { get; set; }
        //public Player p2;

        //Explosiont test
        Explosion exp1;

        public Game()
        {
            GraphicsEngine.Init();
            level = new Level_1();
            playerBullets = new LinkedList<Bullet>();
            playerRockets = new LinkedList<Rocket>();
            enemyBullets = new LinkedList<Bullet>();
            enemies = new LinkedList<Enemy>();
            foreach (Enemy e in level.Enemies)
            {
                enemies.AddFirst(e);
            }
            
            //p1 = new Player(new A10ThunderBolt(100, 100));
            p1 = new Player(new F14TomCat(100, 100));
            //p1 = new Player(new F20TigerShark(100, 100));
            p1Controls.UP = System.Windows.Forms.Keys.Up;
            p1Controls.DOWN = System.Windows.Forms.Keys.Down;
            p1Controls.LEFT = System.Windows.Forms.Keys.Left;
            p1Controls.RIGHT = System.Windows.Forms.Keys.Right;
            p1Controls.A = System.Windows.Forms.Keys.A;
            p1Controls.B = System.Windows.Forms.Keys.S;

            //Explosion intit
            exp1 = new Explosion(200, 200);
        }
        
        public void Move()
        {
            p1.Move();
            exp1.Move();

            foreach (Enemy e in enemies)
            {
                e.Move();
                Bullet b = e.Fire(p1.plane.Y);
                if (b != null)
                    enemyBullets.AddFirst(b);
            }

            foreach (Bullet b in playerBullets)
            {
                b.Move();
            }

            foreach (Rocket r in playerRockets)
            {
                r.Move();
            }

            foreach (Bullet b in enemyBullets)
            {
                b.Move();
            }

            if (p1.plane.keys.ctrl == 1)
            {
                Bullet b = p1.FireBullet();
                if (b != null)
                    playerBullets.AddFirst(b);
            }

            if (p1.plane.keys.alt == 1)
            {
                Rocket r = p1.FireRocket();
                if (r != null)
                    playerRockets.AddFirst(r); //ili AddLast?
            }
            Remove();
            Collision();
        }

        private void Remove()
        {
            LinkedList<Rocket> deleteRockets = new LinkedList<Rocket>();
            LinkedList<Bullet> deletePlayerBullets = new LinkedList<Bullet>();
            LinkedList<Bullet> deleteEnemyBullets = new LinkedList<Bullet>();

            //Remove
            foreach (Bullet b in playerBullets)
            {
                if ((b.X >= BoundsX - 50) || (b.X <= 10) || (b.Y <= 10) || (b.Y >= BoundsY - 50))
                    deletePlayerBullets.AddFirst(b);
            }

            foreach (Rocket r in playerRockets)
            {
                if (r.X >= BoundsX - 50)
                    deleteRockets.AddFirst(r);
            }

            //10 to 0
            foreach (Bullet b in enemyBullets)
            {
                if ((b.X >= BoundsX - 50) || (b.X <= 10) || (b.Y <= 10) || (b.Y >= BoundsY - 50))
                    deleteEnemyBullets.AddFirst(b);
            }

            foreach (Rocket r in deleteRockets)
            {
                playerRockets.Remove(r);
            }

            foreach (Bullet b in deletePlayerBullets)
            {
                playerBullets.Remove(b);
            }

            foreach (Bullet b in deleteEnemyBullets)
            {
                enemyBullets.Remove(b);
            }
        }

        private void Collision()
        {
            LinkedList<Bullet> deletePlayerBullets = new LinkedList<Bullet>();
            LinkedList<Rocket> deletePlayerRockets = new LinkedList<Rocket>();
            LinkedList<Bullet> deleteEnemyBullets = new LinkedList<Bullet>();
            LinkedList<Enemy> deleteEnemies = new LinkedList<Enemy>();

            foreach (Enemy e in enemies)
            {
                foreach (Rocket r in playerRockets)
                {
                    if (r.Hit(e))
                    {
                        
                        deletePlayerRockets.AddFirst(r);
                        e.Health -= r.Damage;
                        if (e.Health <= 0)
                            deleteEnemies.AddFirst(e);
                        continue;
                    }
                }

                if (p1.plane.Hit(e))
                {
                    p1.Health -= 20;
                    deleteEnemies.AddFirst(e);
                }

                // Enemy-Player collision TO-DO5
            }

            foreach (Bullet b in enemyBullets)
            {
                if (p1.plane.Hit(b))
                {
                    deleteEnemyBullets.AddFirst(b);
                    p1.Health -= b.Damage;
                    if (p1.Health <= 0)
                    {
                        p1.Lives -= 1;
                        p1.Health = 100;
                    }
                    //if (p1.Lives == 0)
                    //    GameOver();
                }
            }

            foreach (Bullet b in deletePlayerBullets)
                playerBullets.Remove(b);

            foreach (Rocket r in deletePlayerRockets)
                playerRockets.Remove(r);

            foreach (Bullet b in deleteEnemyBullets)
                enemyBullets.Remove(b);

            foreach (Enemy e in deleteEnemies)
                enemies.Remove(e);

        }

        public void Draw(Graphics g)
        {
            level.Draw(g);
            p1.Draw(g);
            exp1.Draw(g);

            foreach (Enemy e in enemies)
            {
                e.Draw(g);
            }

            foreach (Bullet b in playerBullets)
            {
                b.Draw(g);
            }

            foreach (Rocket r in playerRockets)
            {
                r.Draw(g);
            }

            foreach (Bullet b in enemyBullets)
            {
                b.Draw(g);
            }

            g.DrawString(string.Format("Lives: {0}, Health: {1}", p1.Lives, p1.Health), 
                new Font(FontFamily.GenericMonospace, 12), 
                new SolidBrush(Color.Red), 
                new PointF(10, 10));
        }
    }
}
