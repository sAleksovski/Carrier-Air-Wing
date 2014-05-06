using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CarrierAirWing
{
    public class A10Thunderbolt : Plane
    {
        public A10Thunderbolt(float x, float y) : base(x, y)
        {
            sprite = GraphicsEngine.planeSprites[1][0];
        }

        protected override void ChangeSprite()
        {
            if (keys.up == 1)
                sprite = GraphicsEngine.planeSprites[1][1];
            else if (keys.down == 1)
                sprite = GraphicsEngine.planeSprites[1][2];
            else
                sprite = GraphicsEngine.planeSprites[1][0];
        }

        public override Bullet FireBullet()
        {
            if (BulletCountdown == 0)
            {
                BulletCountdown = 10;
                return new Bullet(X + sprite.Width * 0.9F, Y + 3, 5, 0, 20);
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
                return new Rocket(X + sprite.Width * 0.8F, Y+5, 12, 0, 1, 50); //Rocket 1
                //return new Rocket(X + sprite.Width * 0.8F, Y + 5, 12, 0, 0, 20); //Rocket 0
                
            }
            return null;
        }

    }
}
