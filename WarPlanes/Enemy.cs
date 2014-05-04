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
            SpriteDraw = Properties.Resources.MiG_51S_Down;
            MoveX = -5;
            MoveY = 0;
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
            Pen p = new Pen(new SolidBrush(Color.Red));
            g.DrawEllipse(p, Location.X, Location.Y, 30, 30);
        }

        public override Bullet Fire()
        {
            throw new NotImplementedException();
        }

        private double distance(Point A, Point B)
        {
            return Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));
        }
    }
}
