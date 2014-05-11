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
        private int spriteIndex;
        public int X { get; set; }
        public int Y { get; set; }
        public int SpeedX { get; set; }
        public int SpeedY { get; set; }
        public EnemyMovement[] movement;
        public int currentMovement;
        public int ticks;
        public int CanFire;
        public int Health;

        // Posle kolko vreme da ispuca metak
        private int fireDelay;

        // Konstruktor bez fireDelay
        public Enemy(int x, int y, EnemyMovement[] m, int sr, int health)
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
        }

        // Konstruktor sas fireDelay
        public Enemy(int x, int y, EnemyMovement[] m, int sr, int health, int fireDelay)
            : this(x, y, m, sr, health)
        {
            this.fireDelay = fireDelay;
        }

        // Konstruktor sas tip i fireDelay
        public Enemy(int x, int y, EnemyMovement[] m, int sr, int health, int type, int fireDelay)
            : this(x, y, m, sr, health, fireDelay)
        {
            //Da se doimplementira
        }

        public void Move()
        {
            ticks++;
            ChangeSprite();

            X += SpeedX;
            Y += SpeedY;
            if (ticks == movement[currentMovement].steps)
            {
                ticks = 0;
                currentMovement = (currentMovement + 1) % movement.Length;
                if (currentMovement == 0) currentMovement = 1;
                SpeedX = movement[currentMovement].SpeedX;
                SpeedY = movement[currentMovement].SpeedY;
            }

            if (CanFire > 0)
                CanFire--;
        }

        public void ChangeSprite()
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

            if (differenceY < 500 && differenceX < 500)
            {
                CanFire = fireDelay;
                int signX = (x < X) ? -1 : 1;
                int signY = (y < Y) ? -1 : 1;
                double agol = Math.Atan2(differenceY, differenceX);
                return new Bullet(X, Y, (int)(5 * Math.Cos(agol) * signX), (int)(5 * Math.Sin(agol) * signY), 15);
            }

            return null;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(Sprite, X, Y);
        }

        public bool Hit(Rocket r)
        {
            if (Rectangle.Intersect(new Rectangle(X, Y, Sprite.Width, Sprite.Height), new Rectangle(r.X, r.Y, r.Sprite.Width, r.Sprite.Height)).IsEmpty)
                return false;

            if (GraphicsEngine.enemySprites[spriteIndex].Length == 3)
                Sprite = GraphicsEngine.enemySprites[spriteIndex][2];

            return true;
        }

    }
}
