﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

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
        public int TTL { get; set; }
        public bool GameInProgress { get; set; }
        public bool CanClose { get; set; }
        LinkedList<LinkedListNode<Bullet>> deleteEnemyBullets;
        LinkedList<LinkedListNode<Explosion>> deleteExplosions;
        LinkedList<LinkedListNode<Rocket>> deletePlayerRockets;
        LinkedList<LinkedListNode<Enemy>> deleteEnemies;
        LinkedList<LinkedListNode<EnemyWrapper>> brisi;

        public Game(int boundsX, int boundsY)
        {
            Level.ITERATION = 1;
            level = new Level_1();
            playerBullets = new LinkedList<Bullet>();
            playerRockets = new LinkedList<Rocket>();
            enemyBullets = new LinkedList<Bullet>();
            enemies = new LinkedList<Enemy>();
            explosions = new LinkedList<Explosion>();

            // Init LinkedLists
            deleteEnemyBullets = new LinkedList<LinkedListNode<Bullet>>();
            deleteExplosions = new LinkedList<LinkedListNode<Explosion>>();
            deletePlayerRockets = new LinkedList<LinkedListNode<Rocket>>();
            deleteEnemies = new LinkedList<LinkedListNode<Enemy>>();
            brisi = new LinkedList<LinkedListNode<EnemyWrapper>>();

            if (Settings.chosenPlane == 0)
                p1 = new Player(new F20TigerShark(100, 100, boundsX, boundsY));
            else if (Settings.chosenPlane == 1)
                p1 = new Player(new F14TomCat(100, 100, boundsX, boundsY));
            else
                p1 = new Player(new A10ThunderBolt(100, 100, boundsX, boundsY));

            BoundsX = boundsX;
            BoundsY = boundsY;

            p1Controls.UP = System.Windows.Forms.Keys.Up;
            p1Controls.DOWN = System.Windows.Forms.Keys.Down;
            p1Controls.LEFT = System.Windows.Forms.Keys.Left;
            p1Controls.RIGHT = System.Windows.Forms.Keys.Right;
            p1Controls.A = System.Windows.Forms.Keys.A;
            p1Controls.B = System.Windows.Forms.Keys.S;

            GameInProgress = true;
            CanClose = false;
        }

        public void Move()
        {
            if (!GameInProgress)
            {
                TTL--;
                if (TTL <= 0)
                    return;
            }

            if (GameInProgress)
            {
                level.Tick();

                if (level.Enemies.Count != 0)
                {
                    LinkedListNode<EnemyWrapper> temp = level.Enemies.First;
                        
                    while (temp != null && (temp.Value.Ticks <= level.Ticks))
                    {
                        enemies.AddLast(temp.Value.EnemyPlane);
                        brisi.AddLast(temp);
                        temp = temp.Next;
                    }

                    foreach (LinkedListNode<EnemyWrapper> e in brisi)
                        level.Enemies.Remove(e);
                    brisi = new LinkedList<LinkedListNode<EnemyWrapper>>();

                    // LinkedList<T>.Clear();
                    // This method is an O(n) operation, where n is Count.
                }
            }

            if (level.CanLevelUP && enemies.Count == 0)
                level = level.LevelUP();

            p1.Move();

            for (LinkedListNode<Explosion> e = explosions.First; e != null; e = e.Next)
            {
                if (e.Value.Status == -1)
                {
                    //Debug.Print("Explosion for delete added");
                    deleteExplosions.AddLast(e);
                    continue;
                }

                e.Value.Move();
            }

            for (LinkedListNode<Enemy> e = enemies.First; e != null; e = e.Next)
            {
                if (e.Value.Status == -1 && (e.Value.X - e.Value.Sprite.Width <= 0 || e.Value.Y - e.Value.Sprite.Width <= 0 || e.Value.X >= BoundsX || e.Value.Y >= BoundsY))
                {
                    //Debug.Print("Enemy for delete added");
                    deleteEnemies.AddLast(e);
                    continue;
                }

                e.Value.Move();
                Bullet b = e.Value.Fire(p1.plane.X, p1.plane.Y);
                if (b != null)
                    enemyBullets.AddLast(b);
            }

            for (LinkedListNode<Rocket> r = playerRockets.First; r != null; r = r.Next)
            {
                if (r.Value.X >= BoundsX - 50)
                {
                    //Debug.Print("Rocket for delete added");
                    deletePlayerRockets.AddLast(r);
                    continue;
                }

                r.Value.Move();
            }

            for (LinkedListNode<Bullet> b = enemyBullets.First; b != null; b = b.Next )
            {
                if ((b.Value.X >= BoundsX) || (b.Value.X <= 0) || (b.Value.Y <= 0) || (b.Value.Y >= BoundsY))
                {
                    //Debug.Print("Bullet for delete added");
                    deleteEnemyBullets.AddLast(b);
                    continue;
                }

                b.Value.Move();
            }



            if (p1.plane.keys.ctrl == 1)
            {
                // Super Fire ...
            }

            if (p1.plane.keys.alt == 1)
            {
                Rocket r = p1.FireRocket();
                if (r != null)
                    playerRockets.AddLast(r); //ili AddLast?

            }

            foreach (LinkedListNode<Enemy> e in deleteEnemies)
                enemies.Remove(e);
            deleteEnemies = new LinkedList<LinkedListNode<Enemy>>();

            foreach (LinkedListNode<Rocket> r in deletePlayerRockets)
                playerRockets.Remove(r);
            deletePlayerRockets = new LinkedList<LinkedListNode<Rocket>>();

            foreach (LinkedListNode<Bullet> b in deleteEnemyBullets)
                enemyBullets.Remove(b);
            deleteEnemyBullets = new LinkedList<LinkedListNode<Bullet>>();

            foreach (LinkedListNode<Explosion> e in deleteExplosions)
                explosions.Remove(e);
            deleteExplosions = new LinkedList<LinkedListNode<Explosion>>();


            for (LinkedListNode<Enemy> e = enemies.First; e != null; e = e.Next)
            {
                for (LinkedListNode<Rocket> r = playerRockets.First; r != null; r = r.Next )
                {
                    if (e.Value.Hit(r.Value))
                    {
                        deletePlayerRockets.AddLast(r);
                        e.Value.Health -= r.Value.Damage;
                        Score += 5;
                        if (e.Value.Health <= 0)
                        {
                            deleteEnemies.AddLast(e);
                            e.Value.Health = -1;
                            explosions.AddLast(new Explosion(e.Value.X, e.Value.Y));
                            Score += 10;
                        }
                    }
                }

                if (p1.plane.Hit(e.Value))
                {
                    p1.Health = 100;
                    p1.Lives -= 1;
                    Score += 10;
                    deleteEnemies.AddLast(e);
                    explosions.AddLast(new Explosion(e.Value.X, e.Value.Y));
                    if (p1.Lives == 0)
                        GameOver();
                }
            }

            //
            for (LinkedListNode<Bullet> b = enemyBullets.First; b != null; b = b.Next )
            {
                if (p1.plane.Hit(b.Value))
                {
                    deleteEnemyBullets.AddLast(b);
                    p1.Health -= b.Value.Damage;
                    if (p1.Health <= 0)
                    {
                        p1.Lives -= 1;
                        p1.Health = 100;
                    }
                    if (p1.Lives == 0)
                        GameOver();
                }
            }


            foreach (LinkedListNode<Rocket> r in deletePlayerRockets)
            {
                try
                {
                    playerRockets.Remove(r);
                }
                catch (Exception ex)
                {
                    // ...
                }
            }
            deletePlayerRockets = new LinkedList<LinkedListNode<Rocket>>();

            foreach (LinkedListNode<Bullet> b in deleteEnemyBullets)
                enemyBullets.Remove(b);
            deleteEnemyBullets = new LinkedList<LinkedListNode<Bullet>>();

            foreach (LinkedListNode<Enemy> e in deleteEnemies)
            {
                try
                {
                    enemies.Remove(e);
                }
                catch (Exception ex)
                {
                    // e ajde de ... duplikat enemie za brisanje
                }
            }
            deleteEnemies = new LinkedList<LinkedListNode<Enemy>>();
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
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, 64, 69);
            g.DrawImage(p1.plane.PlayerFace, 1, 0);
            g.DrawRectangle(new Pen(Color.Black, 2), 1, 1, 64, 69);

            g.FillRectangle(new SolidBrush(Color.Red), 65, 50, 200, 20);
            g.DrawLine(new Pen(Color.Yellow, 20), 65, 60, (int)(65 + p1.Health * 2), 60);
            g.DrawRectangle(new Pen(Color.Black, 2), 65, 50, 200, 20);

            g.DrawString(string.Format("Level: {0}", (Level.ITERATION - 1) * 3 + level.Lvl),
                new Font(FontFamily.GenericSansSerif, 13, FontStyle.Bold),
                new SolidBrush(Color.Gold),
                new PointF(67, 2));

            g.DrawString(string.Format("Lives: {0}", p1.Lives),
                new Font(FontFamily.GenericSansSerif, 13, FontStyle.Bold),
                new SolidBrush(Color.White),
                new PointF(67, 27));

            g.DrawString(string.Format("Score: {0}", Score.ToString()),
                new Font(FontFamily.GenericSansSerif, 13, FontStyle.Bold),
                new SolidBrush(Color.White),
                new PointF(160, 27));
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
            CanClose = true;
        }
    }
}
