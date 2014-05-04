using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WarPlanes
{
    public class Game
    {
        public Level level;
        public Player p1;
        //public Player p2;
        public List<Enemy> enemies;
        public List<Bullet> playerBullets;
        public List<Bullet> enemyBullets;
        public int score;

        public Game()
        {
            level = new Level();
            p1 = new Player(new MiG_51S(new Point(100, 100)));
            enemies = new List<Enemy>();
            enemies.AddRange(level.Enemies);
            playerBullets = new List<Bullet>();
            enemyBullets = new List<Bullet>();
            score = 0;
        }
        
        public void Move()
        {
            p1.Move();
            foreach (Enemy e in enemies)
            {
                e.Move();
                Bullet b = e.Fire(p1.plane.Location);
                if (b != null)
                    enemyBullets.Add(b);
                //Bullet b = e.Fire(p1.plane.Location);
                //if (b != null)
                //    enemyBullets.Add(b);
            }
            foreach (Bullet b in playerBullets)
            {
                b.Move();
            }
            foreach (Bullet b in enemyBullets)
            {
                b.Move();
            }
            if (score >= level.ScoreToLevelUp || enemies.Count == -1) // enemies.Count == 0, josh nema enemies zatoj -1
            {
                level = level.LevelUP();
                enemies.AddRange(level.Enemies);
            }
            Collision();
        }

        private void Collision()
        {
            List<Bullet> playerBulletsToRemove = new List<Bullet>();
            List<Bullet> enemyBulletsToRemove = new List<Bullet>();
            List<Enemy> enemiesToRemove = new List<Enemy>();
            
            foreach (Enemy e in enemies)
            {
                foreach (Bullet b in playerBullets)
                {
                    if (e.Hit(b))
                    {
                        playerBulletsToRemove.Add(b);
                        enemiesToRemove.Add(e);
                    }
                }
                if (e.Hit(new Bullet(p1.plane.Location, 0, 0)))
                    enemiesToRemove.Add(e);
            }

            foreach (Bullet b in playerBullets)
            {
                if (b.Location.X > 800 || b.Location.X < 0 || b.Location.Y > 600 || b.Location.Y < 0)
                        playerBulletsToRemove.Add(b);
            }

            foreach (Bullet b in enemyBullets)
            {
                if (p1.plane.Hit(b))
                {
                    score -= 100;           // TO-DO?
                    enemyBulletsToRemove.Add(b);
                }
                if (b.Location.X > 800 || b.Location.X < 0 || b.Location.X > 600 || b.Location.Y < 0)
                    enemyBulletsToRemove.Add(b);
            }

            foreach (Bullet b in playerBulletsToRemove)
            {
                playerBullets.Remove(b);
            }

            foreach (Bullet b in enemyBulletsToRemove)
            {
                enemyBullets.Remove(b);
            }

            foreach (Enemy e in enemiesToRemove)
            {
                enemies.Remove(e);
            }
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
            foreach (Bullet b in enemyBullets)
            {
                b.Draw(g);
            }
            Brush br = new SolidBrush(Color.Red);
            g.DrawString(score.ToString(), new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold), br, new PointF(10f, 20f));
        }

        public void Fire(Player p)
        {
            playerBullets.Add(p.Fire());
            score += 10;
        }
    }
}
