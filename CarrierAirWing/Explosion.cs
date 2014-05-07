using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CarrierAirWing
{
    public class Explosion
    {
        public Bitmap Sprite { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Status { get; set; }
        private int ticks;
        private int spriteIndex;

        public Explosion(int x, int y)
        {
            X = x;
            Y = y;
            ticks = 2;
            spriteIndex = 0;
            Status = 0;
            Sprite = GraphicsEngine.explosionSprites[0][0];
        }

        public void Move()
        {
            if (ticks == 0)
            {
                ticks = 2;
                spriteIndex++;

                if (spriteIndex >= GraphicsEngine.explosionSprites[0].Length)
                    Status = -1;
                else
                    Sprite = GraphicsEngine.explosionSprites[0][spriteIndex];
            }
            else
            {
                ticks--;
            }
        }

        public void Draw(Graphics g)
        {
            if (Status != -1)
                g.DrawImage(Sprite, X - Sprite.Width / 2, Y -Sprite.Height / 2);
        }
    }
}
