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

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }

        public override Bullet Fire()
        {
            throw new NotImplementedException();
        }
    }
}
