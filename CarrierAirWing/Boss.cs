using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarrierAirWing
{
    public class Boss : Enemy
    {
         // Konstruktor sas tip i fireDelay
        public Boss(int x, int y, EnemyMovement[] m, int health, int type, int fireDelay)
            : base(x, y, m, health, type, fireDelay)
        {
        }

        public override void Move()
        {
            ticks++;
            ChangeSprite();

            X += SpeedX;
            Y += SpeedY;
            if (ticks == movement[currentMovement].steps)
            {
                ticks = 0;
                currentMovement = (currentMovement + 1) % movement.Length;
                SpeedX = movement[currentMovement].SpeedX;
                SpeedY = movement[currentMovement].SpeedY;
            }

            if (CanFire > 0)
                CanFire--;
        }

    }
}
