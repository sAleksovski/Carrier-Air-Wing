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

        public Game()
        {
            GraphicsEngine.Init();
            level = new Level_1();
            playerBullets = new LinkedList<Bullet>();
            playerRockets = new LinkedList<Rocket>();
            enemies = new LinkedList<Enemy>();
            foreach (Enemy e in level.Enemies)
            {
                enemies.AddFirst(e);
            }
            //p1 = new Player(new A10Thunderbolt(100, 100));
            p1 = new Player(new F14Tomcat(100, 100));
            p1Controls.UP = System.Windows.Forms.Keys.Up;
            p1Controls.DOWN = System.Windows.Forms.Keys.Down;
            p1Controls.LEFT = System.Windows.Forms.Keys.Left;
            p1Controls.RIGHT = System.Windows.Forms.Keys.Right;
            p1Controls.A = System.Windows.Forms.Keys.A;
            p1Controls.B = System.Windows.Forms.Keys.S;
        }
        
        public void Move()
        {
            p1.Move();

            foreach (Enemy e in enemies)
            {
                e.Move();
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

            LinkedList<Rocket> deleteRockets = new LinkedList<Rocket>();
            LinkedList<Bullet> deletePlayerBullets = new LinkedList<Bullet>();

            foreach (Bullet b in playerBullets)
            {
                if (b.X >= BoundsX - 50)
                {
                    deletePlayerBullets.AddFirst(b);
                }
                else
                {
                    b.Move();
                }
            }

            foreach (Rocket r in playerRockets)
            {
                if (r.X >= BoundsX - 50)
                {
                    deleteRockets.AddFirst(r);
                }
                else
                {
                    r.Move();
                }
            }

            foreach (Rocket r in deleteRockets)
            {
                playerRockets.Remove(r);
            }

            foreach (Bullet b in deletePlayerBullets)
            {
                playerBullets.Remove(b);
            }

            Collision();
        }

        private void Collision()
        {
           
        }

        public void Draw(Graphics g)
        {
            level.Draw(g);
            p1.Draw(g);

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
        }
    }
}
