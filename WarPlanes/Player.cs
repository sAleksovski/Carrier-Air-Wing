using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WarPlanes
{
    public class Player
    {
        public Plane plane;
        public int Lives { get; set; }
        public int Score { get; set; }

        public Player(Plane p)
        {
            plane = p;
        }

        public void Move()
        {
            plane.Move();
        }

        public void Draw(Graphics g)
        {
            plane.Draw(g);
        }

        public Rocket Fire()
        {
            return plane.Fire();
        }
    }
}
