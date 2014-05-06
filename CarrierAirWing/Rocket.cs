using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CarrierAirWing
{
    public class Rocket
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float SpeedX { get; set; }
        public float SpeedY { get; set; }
        public int Status { get; set; }
        public int Damage { get; set; }
        private int spriteIndex;

        public Rocket(float x, float y, float speedX, float speedY, int spriteIndex, int damage)
        {
            X = x;
            Y = y;
            SpeedX = speedX;
            SpeedY = speedY;
            Status = 0;
            this.spriteIndex = spriteIndex;
            Damage = damage;
        }

        public void Move()
        {
            X += SpeedX;
            Y += SpeedY;
            Status = (Status + 1) % 2;
        }

        public virtual void Draw(Graphics g)
        {
            //g.DrawImage(GraphicsEngine.rocketSprites[Status], X, Y, GraphicsEngine.rocketSprites[Status].Width * 0.15F, GraphicsEngine.rocketSprites[Status].Height * 0.15F);
            //g.DrawImage(GraphicsEngine.rocketSprites[Status], X, Y);
            g.DrawImage(GraphicsEngine.rocketSprites[spriteIndex][Status], X, Y);
        }
    }
}
