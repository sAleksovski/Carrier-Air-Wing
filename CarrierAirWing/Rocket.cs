﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CarrierAirWing
{
    public class Rocket
    {
        public Bitmap Sprite { get; set; }
        private int spriteIndex;
        public int X { get; set; }
        public int Y { get; set; }
        public int SpeedX { get; set; }
        public int SpeedY { get; set; }
        public int Status { get; set; }
        public int Damage { get; set; }

        public Rocket(int x, int y, int speedX, int speedY, int spriteIndex, int damage)
        {
            X = x;
            Y = y;
            SpeedX = speedX;
            SpeedY = speedY;
            Status = 0;
            this.spriteIndex = spriteIndex;
            Damage = damage;
            Sprite = GraphicsEngine.rocketSprites[spriteIndex][Status];
            SoundEngine.PlayRocketSound();
        }

        public void Move()
        {
            X += SpeedX;
            Y += SpeedY;
            Status = (Status + 1) % 2;
            Sprite = GraphicsEngine.rocketSprites[spriteIndex][Status];
        }

        public virtual void Draw(Graphics g)
        {
            g.DrawImage(Sprite, X, Y);
        }

    }
}
