using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CarrierAirWing
{
    public class Bullet
    {
        public Point Location;
        public float X;
        public float Y;
        public float MoveX;
        public float MoveY;

        public Bullet(float x, float y, float mx, float my)
        {
            X = x;
            Y = y;
            MoveX = mx;
            MoveY = my;
        }

        public void Move()
        {
            X += MoveX;
            Y += MoveY;
        }

        public void Draw(Graphics g)
        {
            g.DrawImageUnscaled(Properties.Resources.Bullet, Location.X, Location.Y);
        }
    }
}
