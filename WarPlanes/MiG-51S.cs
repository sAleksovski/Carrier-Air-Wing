using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WarPlanes
{
    class MiG_51S : PlayerPlane
    {
        public MiG_51S(Point p) : base()
        {
            Location = p;
            SpriteForward = Properties.Resources.MiG_51S_Top;
            SpriteUp = Properties.Resources.MiG_51S_Up;
            SpriteDown = Properties.Resources.MiG_51S_Down;
            SpriteDraw = SpriteForward;
            MoveX = 5;
            MoveY = 5;
        }


        public override void Move()
        {
            int x = 0;
            int y = 0;

            if (PM.RIGHT)
                x = MoveX;
            else if (PM.LEFT)
                x = -MoveX;
            if (PM.UP)
            {
                y = -MoveY;
                SpriteDraw = SpriteUp;
            }
            else if (PM.DOWN)
            {
                y = 5;
                SpriteDraw = SpriteDown;
            }
            else
            {
                SpriteDraw = SpriteForward;
            }
                

            Location = new Point(Location.X + x, Location.Y + y);
        }

        public override void Draw(Graphics g)
        {
            g.DrawImageUnscaled(SpriteDraw, Location.X - SpriteDraw.Width / 2, Location.Y - SpriteDraw.Height / 2);
        }

        public override Bullet Fire()
        {
            return new Bullet(new Point(Location.X + SpriteDraw.Width/2, Location.Y), 10, 0);
        }
    }
}
