using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

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


        public Enemy(int x, int y, EnemyMovement[] m, int sr, int health)
        {
            X = x;
            Y = y;
            movement = m;
            ticks = 0;
            currentMovement = 0;
            SpeedX = movement[currentMovement].SpeedX;
            SpeedY = movement[currentMovement].SpeedY;
            spriteIndex = GraphicsEngine.randomizer.Next(22);
            Sprite = GraphicsEngine.enemySprites[spriteIndex][0];
            Health = health;
            CanFire = 0;
        }

        public void Move()
        {
            ticks++;
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

            if (ticks % 4 == 0)
                Sprite = GraphicsEngine.enemySprites[spriteIndex][0];
            else
                Sprite = GraphicsEngine.enemySprites[spriteIndex][1];
            //ChangeSprite();
        }

        public void ChangeSprite()
        {
            //if(SpeedY < 0)
            //    Sprite = GraphicsEngine.enemySprites[spriteRow][1];
            //else if(SpeedY > 0)
            //    Sprite = GraphicsEngine.enemySprites[spriteRow][2];
            //else
            //    Sprite = GraphicsEngine.enemySprites[spriteRow][0];
        }

        public Bullet Fire(float y)
        {
            if (Math.Abs(y - Y) < 20 && CanFire == 0)
            {
                CanFire = 20;
                return new Bullet(X, Y, -5, 0, 25);
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
            return true;
        }

        public bool Hit(Bullet b)
        {
            if (Rectangle.Intersect(new Rectangle(X, Y, Sprite.Width, Sprite.Height), new Rectangle(b.X, b.Y, Properties.Resources.bullet0.Width, Properties.Resources.bullet0.Height)).IsEmpty)
                return false;
            return true;
        }
    }
}
