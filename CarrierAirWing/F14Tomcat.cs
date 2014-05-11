using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CarrierAirWing
{
    public class F14TomCat : Plane
    {
        public F14TomCat(int x, int y)
            : base(x, y)
        {
            Sprite = GraphicsEngine.planeSprites[1][0];
            PlayerFace = GraphicsEngine.playerFaceSprites[1];
        }

        protected override void ChangeSprite()
        {
            if (keys.up == 1)
                Sprite = GraphicsEngine.planeSprites[1][1];
            else if (keys.down == 1)
                Sprite = GraphicsEngine.planeSprites[1][2];
            else
                Sprite = GraphicsEngine.planeSprites[1][0];
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
                return new Rocket((int)(X + Sprite.Width * 0.85F), Y - 2, 12, 0, 1, 20); //Rocket 1
            }
            return null;
        }
    }
}
