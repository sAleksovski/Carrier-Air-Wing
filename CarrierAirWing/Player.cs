using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CarrierAirWing
{
    public class Player
    {
        public Plane plane;
        public int Lives { get; set; }
        public int Score { get; set; }
        public int Health { get; set; }

        public Player(Plane p)
        {
            plane = p;
            Lives = 3;
            Score = 0;
            Health = 100;
        }

        public void Move()
        {
            plane.Move();
        }

        public void Draw(Graphics g)
        {
            plane.Draw(g);
        }

        public Bullet FireBullet()
        {
            return plane.FireBullet();
        }

        public Rocket FireRocket()
        {
            return plane.FireRocket();
        }
    }
}
