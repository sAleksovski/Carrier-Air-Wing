using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CarrierAirWing
{
    public class Bullet
    {
        public float X;
        public float Y;
        public float MoveX;
        public float MoveY;
        public int Damage { get; set; }

        public Bullet(float x, float y, float mx, float my, int damage)
        {
            X = x;
            Y = y;
            MoveX = mx;
            MoveY = my;
            Damage = damage;
        }

        public void Move()
        {
            X += MoveX;
            Y += MoveY;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(Properties.Resources.Bullet, X, Y);
        }
    }
}
