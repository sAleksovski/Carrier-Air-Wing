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
        public int MoveX;
        public int MoveY;

        public Bullet(Point l, int x, int y)
        {
            Location = l;
            MoveX = x;
            MoveY = y;
        }

        public void Move()
        {
            Location = new Point(Location.X + MoveX, Location.Y + MoveY);
        }

        public void Draw(Graphics g)
        {
            g.DrawImageUnscaled(Properties.Resources.Bullet, 
                Location.X - Properties.Resources.Bullet.Width / 2, 
                Location.Y - Properties.Resources.Bullet.Height / 2);
        }
    }
}
