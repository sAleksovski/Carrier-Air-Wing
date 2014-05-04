using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WarPlanes
{
    public abstract class PlayerPlane : Plane
    {
        public PlayerMove PM;
        public int MoveX;
        public int MoveY;

        public PlayerPlane()
        {
            PM.UP = false;
            PM.DOWN = false;
            PM.LEFT = false;
            PM.RIGHT = false;
        }

        public PlayerPlane(Point l, Image sf, Image su, Image sd) : base(l, sf, su, sd)
        {
            PM.UP = false;
            PM.DOWN = false;
            PM.LEFT = false;
            PM.RIGHT = false;
        }
    }
}
