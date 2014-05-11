using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CarrierAirWing
{
    public class A10ThunderBolt : Plane
    {
        public A10ThunderBolt(int x, int y, int boundsX, int boundsY)
            : base(x, y, boundsX, boundsY)
        {
            Sprite = GraphicsEngine.planeSprites[2][0];
            PlayerFace = GraphicsEngine.playerFaceSprites[2];
        }

        protected override void ChangeSprite()
        {
            if (keys.up == 1)
                Sprite = GraphicsEngine.planeSprites[2][1];
            else if (keys.down == 1)
                Sprite = GraphicsEngine.planeSprites[2][2];
            else
                Sprite = GraphicsEngine.planeSprites[2][0];
        }

        public Bullet FireBullet()
        {
            if (BulletCountdown == 0)
            {
                BulletCountdown = 10;
                return new Bullet((int)(X + Sprite.Width * 0.9F), Y + 3, 5, 0, 20);
            }
            return null;
        }

        public override Rocket FireRocket()
        {
            if (RocketCountdown == 0 && RocketBlocked == false)
            {
                RocketCountdown = 3;
                RocketsLaunched++;
                if (RocketsLaunched == 14)
                    RocketBlocked = true;
                //return new Rocket(X + sprite.Width * 0.8F, Y, 12, 0, 2, 20); //Rocket ?
                //return new Rocket(X + sprite.Width * 0.8F, Y+5, 12, 0, 1, 50); //Rocket ?
                return new Rocket((int)(X + Sprite.Width * 0.85F), Y + 5, 12, 0, 2, 20); //Rocket 2

            }
            return null;
        }

    }
}
