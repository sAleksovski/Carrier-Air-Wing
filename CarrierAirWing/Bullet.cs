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
        public float X;
        public float Y;
        public float MoveX;
        public float MoveY;
        public int Damage { get; set; }
        public int Status { get; set; }
        private int type;

        public Bullet(float x, float y, float mx, float my, int damage)
        {
            X = x;
            Y = y;
            MoveX = mx;
            MoveY = my;
            Damage = damage;
            Status = 0;
            //type = GraphicsEngine.randomizer.Next(0, 2);
        }

        public void Move()
        {
            X += MoveX;
            Y += MoveY;
            Status = (Status + 1) % 15;
        }

        public void Draw(Graphics g)
        {
            //if (type == 0)
            //{
                if (Status > 7)
                    g.DrawImage(Properties.Resources.bullet0, X, Y);
                else
                    g.DrawImage(Properties.Resources.bullet2, X, Y);
            //}
            //else
            //{
            //    if (Status > 10)
            //        g.DrawImage(Properties.Resources.bullet2, X, Y);
            //    else
            //       g.DrawImage(Properties.Resources.bullet3, X, Y);
            //}
        }
    }
}
