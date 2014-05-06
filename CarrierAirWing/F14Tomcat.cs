using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CarrierAirWing
{
    public class F14Tomcat : Plane
    {
        public F14Tomcat(float x, float y) : base(x, y)
        {
            sprite = GraphicsEngine.planeSprites[0][0];
        }

        protected override void ChangeSprite()
        {
            if (keys.up == 1)
                sprite = GraphicsEngine.planeSprites[0][1];
            else if (keys.down == 1)
                sprite = GraphicsEngine.planeSprites[0][2];
            else
                sprite = GraphicsEngine.planeSprites[0][0];
        }

        public override Bullet FireBullet()
        {
            if (BulletCountdown == 0)
            {
                BulletCountdown = 10;
                return new Bullet(X + sprite.Width * 0.9F, Y+3, 5, 0, 20);
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
                //return new Rocket(X + sprite.Width * 0.8F, Y, 12, 0, 2, 20); //Rocket 2
                //return new Rocket(X + sprite.Width * 0.8F, Y+5, 12, 0, 1, 20); //Rocket 1
                return new Rocket(X + sprite.Width * 0.8F, Y+5, 12, 0, 0, 50); //Rocket 0
            }
            return null;
        }
    }
}
