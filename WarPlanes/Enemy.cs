using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WarPlanes
{
    public class Enemy : Plane
    {
        //location
        public int MoveX;
        public int MoveY;
        public int CanFire; // Ako e 0, puca
        // currCoord e momentalno nakude se dvizi, kt ke se doblizi do njuma (radius?), 
        // currcoord ke se inkrementira, ke se presmetav MoveX i MoveY za da stigne do 
        // narednu poziciju
        // currCoord = (currCoord + 1) % coordinates.Length();
        public Point[] coordinates;
        public int currCoord;

        public Enemy(Point location, Point[] c)
        {
            Location = location;
            coordinates = c;
            currCoord = 0;
            SpriteDraw = Properties.Resources.test1;
            double d = distance(Location, coordinates[currCoord]);
            int steps = (int)(d / 5);
            MoveX = (coordinates[currCoord].X - Location.X) / steps;
            MoveY = (coordinates[currCoord].Y - Location.Y) / steps;
        }

        public override void Move()
        {
            Location = new Point(Location.X + MoveX, Location.Y + MoveY);
            if (distance(Location, coordinates[currCoord]) < 50)
            {
                currCoord = (currCoord + 1) % coordinates.Length;
                double d = distance(Location, coordinates[currCoord]);
                int steps = (int)(d / 5);
                MoveX = (coordinates[currCoord].X - Location.X) / steps;
                MoveY = (coordinates[currCoord].Y - Location.Y) / steps;
            }
        }

        public override void Draw(Graphics g)
        {
            g.DrawImageUnscaled(SpriteDraw, Location.X - SpriteDraw.Width / 2, Location.Y - SpriteDraw.Height / 2);
        }

        public override Bullet Fire()
        {
            throw new NotImplementedException();
        }

        public Bullet Fire(Point p)
        {
            if (Math.Abs(p.Y - Location.Y) < 20)
            {
                if (CanFire == 0)
                {
                    CanFire = 20;
                    return new Bullet(new Point(Location.X - SpriteDraw.Width / 2, Location.Y), -5, 0);
                }
                else
                {
                    CanFire--;
                }
            }

            if (CanFire > 0)
                CanFire--;

            return null;
        }

        private double distance(Point A, Point B)
        {
            return Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));
        }
    }
}
