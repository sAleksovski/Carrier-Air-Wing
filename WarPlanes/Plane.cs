using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using WarPlanes.Properties;

namespace WarPlanes
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
        public float X { get; set; }
        public float Y { get; set; }
        public float SpeedX { get; set; }
        public float SpeedY { get; set; }

        //Da se implementira
        public int BoundsX { get; set; }
        public int BoundsY { get; set; }

        public Keys keys; //Dali e podobro da se prosleduev na Move() ili da se cuvav tuj?
        public int RocketCountdown { get; set; }
        public int RocketsLaunched { get; set; }
        public bool RocketBlocked { get; set; }

        public int Health { get; set; }
        public int State { get; set; }

        protected Bitmap sprite;

        public Plane(float x, float y)
        {
            this.X = x;
            this.Y = y;
            SpeedX = 6F;
            SpeedY = 6F;
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

            if (RocketCountdown > 0)
                RocketCountdown--;

            if (keys.ctrl == 0)
            {
                RocketBlocked = false;
                RocketsLaunched = 0;
            }
        }

        protected abstract void ChangeSprite();

        public virtual void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Red), X, Y, sprite.Width, sprite.Height);
            g.DrawImage(sprite, X, Y);
        }

        public abstract Rocket Fire();

        public bool Hit(Bullet b)
        {
            return false;
        }
    }

}
