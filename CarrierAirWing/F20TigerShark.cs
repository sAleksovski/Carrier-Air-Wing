using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarrierAirWing
{
    class F20TigerShark : Plane
    {
        public F20TigerShark(int x, int y)
            : base(x, y)
        {
            Sprite = GraphicsEngine.planeSprites[1][0];
        }

        protected override void ChangeSprite()
        {
            if (keys.up == 1)
                Sprite = GraphicsEngine.planeSprites[0][1];
            else if (keys.down == 1)
                Sprite = GraphicsEngine.planeSprites[0][2];
            else
                Sprite = GraphicsEngine.planeSprites[0][0];
        }

        public override Bullet FireBullet()
        {
            if (BulletCountdown == 0)
            {
                BulletCountdown = 10;
                return new Bullet((int)(X + Sprite.Width * 0.9F), Y + 2, 5, 0, 20);
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
                return new Rocket((int)(X + Sprite.Width * 0.8F), Y - 4, 12, 0, 0, 20); //Rocket 0
            }
            return null;
        }
    }
}
