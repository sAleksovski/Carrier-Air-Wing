using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace CarrierAirWing
{
    public struct EnemyMovement
    {
        public int SpeedX;
        public int SpeedY;
        public int steps;
    };

    public class Enemy
    {
        public Bitmap Sprite { get; set; }
        protected int spriteIndex;
        public int X { get; set; }
        public int Y { get; set; }
        public int SpeedX { get; set; }
        public int SpeedY { get; set; }
        public EnemyMovement[] movement;
        protected int currentMovement;
        protected int ticks;
        protected int CanFire;
        public int Health { get; set; }
        public int Status { get; set; }

        // Posle kolko vreme da ispuca metak
        private int fireDelay;

        // Konstruktor bez fireDelay
        public Enemy(int x, int y, EnemyMovement[] m, int health)
        {
            X = x;
            Y = y;
            movement = m;
            ticks = 0;
            currentMovement = 0;
            SpeedX = movement[currentMovement].SpeedX;
            SpeedY = movement[currentMovement].SpeedY;
            spriteIndex = GraphicsEngine.randomizer.Next(23);
            Sprite = GraphicsEngine.enemySprites[spriteIndex][0];
            Health = health;
            CanFire = 0;
            fireDelay = 100;
            Status = 0;
        }

        // Konstruktor sas fireDelay
        public Enemy(int x, int y, EnemyMovement[] m, int health, int fireDelay)
            : this(x, y, m, health)
        {
            this.fireDelay = fireDelay;
        }

        // Konstruktor sas tip i fireDelay
        public Enemy(int x, int y, EnemyMovement[] m, int health, int type, int fireDelay)
            : this(x, y, m, health, fireDelay)
        {
            spriteIndex = type;
        }

        public virtual void Move()
        {
            ticks++;
            ChangeSprite();

            X += SpeedX;
            Y += SpeedY;
            if (ticks == movement[currentMovement].steps)
            {
                ticks = 0;
                currentMovement = (currentMovement + 1) % movement.Length;
                if (currentMovement == 0) Status = -1; // Treba da se testira
                SpeedX = movement[currentMovement].SpeedX;
                SpeedY = movement[currentMovement].SpeedY;
            }

            if (CanFire > 0)
                CanFire--;
        }

        public virtual void ChangeSprite()
        {
            if (ticks % 4 == 0)
                Sprite = GraphicsEngine.enemySprites[spriteIndex][0];
            else
                Sprite = GraphicsEngine.enemySprites[spriteIndex][1];
        }

        // X,Y koordinate na avion na player
        public Bullet Fire(int x, int y)
        {
            if (CanFire != 0)
                return null;

            int differenceX = Math.Abs(x - X);
            int differenceY = Math.Abs(y - Y);

            if (differenceY < 450 && differenceX < 450)
            {
                CanFire = fireDelay;
                int signX = (x < X) ? -1 : 1;
                int signY = (y < Y) ? -1 : 1;
                double agol = Math.Atan2(differenceY, differenceX);
                return new Bullet(X, Y, (int)(7 * Math.Cos(agol) * signX), (int)(7 * Math.Sin(agol) * signY), 15);
            }

            return null;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(Sprite, X, Y);
        }

        public virtual bool Hit(Rocket r)
        {
            if (Rectangle.Intersect(new Rectangle(X, Y, Sprite.Width, Sprite.Height), new Rectangle(r.X, r.Y, r.Sprite.Width, r.Sprite.Height)).IsEmpty)
                return false;

            if (GraphicsEngine.enemySprites[spriteIndex].Length == 3)
                Sprite = GraphicsEngine.enemySprites[spriteIndex][2];

            return true;
        }

    }
}
