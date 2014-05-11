using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CarrierAirWing.Properties;

namespace CarrierAirWing
{
    public struct Keys
    {
        public short up;
        public short right;
        public short down;
        public short left;
        public short ctrl;
        public short alt;
    }

    public abstract class Plane
    {
        protected Bitmap Sprite { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int SpeedX { get; set; }
        public int SpeedY { get; set; }

        //Da se implementira
        public int BoundsX { get; set; }
        public int BoundsY { get; set; }

        public Keys keys; //Dali e podobro da se prosleduev na Move() ili da se cuvav tuj?
        public int BulletCountdown { get; set; }
        public int RocketCountdown { get; set; }
        public int RocketsLaunched { get; set; }
        public bool RocketBlocked { get; set; }

        public int Health { get; set; }
        public int State { get; set; }

        public Bitmap PlayerFace { get; set; }

        public Plane(int x, int y)
        {
            this.X = x;
            this.Y = y;
            SpeedX = 6;
            SpeedY = 6;
            BulletCountdown = 0;
            RocketCountdown = 0;
            RocketBlocked = false;
            RocketsLaunched = 0;
        }

        public void Move()
        {
            X -= keys.left * SpeedX;
            X += keys.right * SpeedX;
            Y += keys.down * SpeedY;
            Y -= keys.up * SpeedY;
            ChangeSprite();

            if (BulletCountdown > 0)
                BulletCountdown--;

            if (RocketCountdown > 0)
                RocketCountdown--;

            if (keys.alt == 0)
            {
                RocketBlocked = false;
                RocketsLaunched = 0;
            }
        }

        protected abstract void ChangeSprite();

        public virtual void Draw(Graphics g)
        {
            g.DrawImage(Sprite, X, Y);
        }

        public abstract Rocket FireRocket();

        public bool Hit(Enemy e)
        {
            if (Rectangle.Intersect(new Rectangle(X, Y, Sprite.Width, Sprite.Height), new Rectangle(e.X, e.Y, e.Sprite.Width, e.Sprite.Height)).IsEmpty)
                return false;
            return true;
        }

        public bool Hit(Bullet b)
        {
            if (Rectangle.Intersect(new Rectangle(X, Y, Sprite.Width, Sprite.Height), new Rectangle(b.X, b.Y, Resources.bullet0.Width, Resources.bullet0.Height)).IsEmpty)
                return false;
            return true;
        }

    }

}
