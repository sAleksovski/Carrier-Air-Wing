using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WarPlanes
{
    public class Player
    {
        public PlayerPlane plane;
        public int Lives { get; set; }

        public Player(PlayerPlane p)
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

        public Bullet Fire()
        {
            return plane.Fire();
        }
    }
}
