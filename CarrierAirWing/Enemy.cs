using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CarrierAirWing
{
    public struct EnemyMovement
    {
        public float SpeedX;
        public float SpeedY;
        public int steps;
    };

    public class Enemy
    {
        public Bitmap sprite;
        public int spriteRow;
        public float X;
        public float Y;
        public float SpeedX;
        public float SpeedY;
        public EnemyMovement[] movement;
        public int currentMovement;
        public int ticks;
        

        public Enemy(float x, float y, EnemyMovement[] m, int sr)
        {
            X = x;
            Y = y;
            movement = m;
            ticks = 0;
            currentMovement = 0;
            SpeedX = movement[currentMovement].SpeedX;
            SpeedY = movement[currentMovement].SpeedY;
            spriteRow = sr;
            //sprite = GraphicsEngine.enemySprites[spriteRow][0];
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
                SpeedX = movement[currentMovement].SpeedX;
                SpeedY = movement[currentMovement].SpeedY;
            }
            //ChangeSprite();
        }

        public void ChangeSprite()
        {
            if(SpeedY < 0)
                sprite = GraphicsEngine.enemySprites[spriteRow][1];
            else if(SpeedY > 0)
                sprite = GraphicsEngine.enemySprites[spriteRow][2];
            else
                sprite = GraphicsEngine.enemySprites[spriteRow][0];
        }

        public Bullet Fire(float y)
        {
            if (Math.Abs(y - Y) < 20)
                return new Bullet(X, Y, -5, 0);
            return null;
        }

        public void Draw(Graphics g)
        {
            //g.DrawImage(sprite, X, Y);
            g.DrawRectangle(new Pen(Color.Red), X, Y, 30, 20);
        }
    }
}
