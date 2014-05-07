using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CarrierAirWing
{
    public class Bullet
    {
        public Bitmap Sprite { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int MoveX { get; set; }
        public int MoveY { get; set; }
        public int Damage { get; set; }
        public int Status { get; set; }
        private int type;

        public Bullet(int x, int y, int mx, int my, int damage)
        {
            X = x;
            Y = y;
            MoveX = mx;
            MoveY = my;
            Damage = damage;
            Status = 0;
            type = GraphicsEngine.randomizer.Next(0, 2);
        }

        public void Move()
        {
            X += MoveX;
            Y += MoveY;
            Status = (Status + 1) % 15;
        }

        public void Draw(Graphics g)
        {
            //Optimize & refactor
            if (type == 0)
            {
                if (Status > 7)
                    g.DrawImage(Properties.Resources.bullet0, X, Y);
                else
                    g.DrawImage(Properties.Resources.bullet1, X, Y);
            }
            else
            {
                if (Status > 10)
                    g.DrawImage(Properties.Resources.bullet2, X, Y);
                else
                    g.DrawImage(Properties.Resources.bullet3, X, Y);
            }
        }
    }
}
