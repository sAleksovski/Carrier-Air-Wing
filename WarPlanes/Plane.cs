using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WarPlanes
{
    public abstract class Plane
    {
        public Point Location;
        public Image SpriteForward;
        public Image SpriteUp;
        public Image SpriteDown;
        public Image SpriteDraw;

        public Plane(){}

        public Plane(Point l, Image sf, Image su, Image sd)
        {
            Location = l;
            SpriteForward = sf;
            SpriteUp = su;
            SpriteDown = sd;
        }

        public abstract void Move();
        public abstract void Draw(Graphics g);
        public abstract Bullet Fire();
        public bool Hit(Bullet b)
        {
            if (Math.Abs(Location.X - b.Location.X) < SpriteDraw.Width / 2 && Math.Abs(Location.Y - b.Location.Y) < SpriteDraw.Height / 2)
            {
                return true;
            }
            return false;
        }
    }

    public struct PlayerMove
    {
        public bool UP;
        public bool DOWN;
        public bool LEFT;
        public bool RIGHT;
    };
}
