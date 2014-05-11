﻿using System;
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
        public LinkedList<Explosion> explosions;
        public int BoundsX { get; set; }
        public int BoundsY { get; set; }
        public int Score { get; set; }
        public bool GameInProgress { get; set; }
        public int TTL { get; set; }
        
        public Game()
        {
            GraphicsEngine.Init();
            level = new Level_1();
            playerBullets = new LinkedList<Bullet>();
            playerRockets = new LinkedList<Rocket>();
            enemyBullets = new LinkedList<Bullet>();
            enemies = new LinkedList<Enemy>();
            explosions = new LinkedList<Explosion>();
            foreach (Enemy e in level.Enemies)
            {
                enemies.AddFirst(e);
            }
            
            //p1 = new Player(new A10ThunderBolt(100, 100));
            //p1 = new Player(new F14TomCat(100, 100));
            if(Settings.chosenPlane == 0)
                p1 = new Player(new F20TigerShark(100, 100));
            else if(Settings.chosenPlane == 1)
                p1 = new Player(new F14TomCat(100, 100));
            else
                p1 = new Player(new A10ThunderBolt(100, 100));

            p1Controls.UP = System.Windows.Forms.Keys.Up;
            p1Controls.DOWN = System.Windows.Forms.Keys.Down;
            p1Controls.LEFT = System.Windows.Forms.Keys.Left;
            p1Controls.RIGHT = System.Windows.Forms.Keys.Right;
            p1Controls.A = System.Windows.Forms.Keys.A;
            p1Controls.B = System.Windows.Forms.Keys.S;

            GameInProgress = true;
        }
        
        public void Move()
        {
            if (!GameInProgress)
            {
                TTL--;
                if(TTL <= 0)
                    return;
            }
                

            p1.Move();
            foreach (Explosion e in explosions)
            {
                e.Move();
            }
            if (GameInProgress)
            {
                if (level.Tick(enemies.Count))
                {
                    foreach (Enemy e in level.Enemies)
                        enemies.AddFirst(e);
                }
            }

            if (level.CanLevelUP)
                level = level.LevelUP();

            foreach (Enemy e in enemies)
            {
                e.Move();
                Bullet b = e.Fire(p1.plane.X, p1.plane.Y);
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
            LinkedList<Explosion> deleteExplosions = new LinkedList<Explosion>();

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

            foreach (Explosion e in explosions)
            {
                if (e.Status == -1)
                    deleteExplosions.AddFirst(e);
            }

            //10 to 0
            foreach (Bullet b in enemyBullets)
            {
                if ((b.X >= BoundsX) || (b.X <= 0) || (b.Y <= 0) || (b.Y >= BoundsY))
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

            foreach (Explosion e in deleteExplosions)
            {
                explosions.Remove(e);
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
                foreach (Bullet b in playerBullets)
                {
                    if(e.Hit(b))
                    {
                        deletePlayerBullets.AddFirst(b);
                        e.Health -= b.Damage;

                        Score += 5;
                        if (e.Health <= 0)
                        {
                            deleteEnemies.AddFirst(e);
                            explosions.AddFirst(new Explosion(e.X, e.Y));
                            Score += 10;
                        }
                        continue;    
                    }
                }

                foreach (Rocket r in playerRockets)
                {
                    if (e.Hit(r))
                    {
                        
                        deletePlayerRockets.AddFirst(r);
                        e.Health -= r.Damage;
                        Score += 5;
                        if (e.Health <= 0)
                        {
                            deleteEnemies.AddFirst(e);
                            explosions.AddFirst(new Explosion(e.X, e.Y));
                            Score += 10;
                        }
                        continue;
                    }
                }

                if (p1.plane.Hit(e))
                {
                    p1.Health = 100;
                    p1.Lives -= 1;
                    Score += 10;
                    deleteEnemies.AddFirst(e);
                    explosions.AddFirst(new Explosion(e.X, e.Y));
                    if (p1.Lives == 0)
                        GameOver();
                }
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
                    if (p1.Lives == 0)
                        GameOver();
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

            foreach (Explosion e in explosions)
            {
                e.Draw(g);
            }

            DrawHUD(g);
        }

        public void DrawHUD(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Red, 3), 1, 1, 220, 88);
            g.DrawImage(p1.plane.PlayerFace, 160, 1);
            g.DrawRectangle(new Pen(Color.Red, 3), 160, 1, 60, 70);
            g.DrawString(string.Format("Lives: {0}", p1.Lives), 
                new Font(FontFamily.GenericMonospace, 16), 
                new SolidBrush(Color.Red), 
                new PointF(5, 3));
            g.DrawString("Health:",
                new Font(FontFamily.GenericMonospace, 16), 
                new SolidBrush(Color.Red),
                new PointF(5, 42));
            g.DrawLine(new Pen(Color.Red, 10), 8, 80, 8 + (int)(2*p1.Health), 80);
            g.DrawString(string.Format("Score: {0}", Score.ToString()),
                new Font(FontFamily.GenericMonospace, 16),
                new SolidBrush(Color.Red),
                new PointF(225, 5));
            g.DrawString(string.Format("Level: {0}", (Level.ITERATION - 1)*3 + level.Lvl),
                new Font(FontFamily.GenericMonospace, 16),
                new SolidBrush(Color.Red),
                new PointF(225, 25));
        }

        public void GameOver()
        {
            GameInProgress = false;
            TTL = 15;
            playerBullets = new LinkedList<Bullet>();
            playerRockets = new LinkedList<Rocket>();
            enemyBullets = new LinkedList<Bullet>();
            enemies = new LinkedList<Enemy>();

            if (Settings.highScores.IsTopTen(Score))
            {
                FormGetName f = new FormGetName();
                f.ShowDialog();
                string name = f.PlayerName;
                if (name == "FormGetName")
                    return;
                Settings.highScores.AddHighScore(new Score(name, Score));
            }
        }
    }
}
