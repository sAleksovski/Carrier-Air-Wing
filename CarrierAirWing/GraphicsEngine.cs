using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using CarrierAirWing.Properties;

namespace CarrierAirWing
{
    public class GraphicsEngine
    {
        public static Bitmap[][] planeSprites = new Bitmap[3][];
        public static Bitmap[][] rocketSprites = new Bitmap[3][];
        public static Bitmap[][] enemySprites = new Bitmap[3][];
        public static Bitmap[] playerFaceSprites = new Bitmap[3];
        public static Bitmap[][] explosionSprites = new Bitmap[2][];
        public static Bitmap Level1;
        public static Bitmap[] Level2 = new Bitmap[6];
        public static Random randomizer;

        public static void Init()
        {
            //Random number generator
            randomizer = new Random();

            // Player Sprites
            //F-20 TigerShark
            //This are 100% correct
            planeSprites[0] = new Bitmap[3];
            Bitmap bmp = new Bitmap(Resources.UNSquadronPlayer);
            Bitmap croped = bmp.Clone(new Rectangle(5, 3, 43, 11), bmp.PixelFormat);
            Bitmap scaled = new Bitmap(croped, (int)(croped.Width * 1.5), (int)(croped.Height * 1.5));
            planeSprites[0][0] = scaled;
            croped = bmp.Clone(new Rectangle(228, 22, 43, 11), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 1.5), (int)(croped.Height * 1.5));
            planeSprites[0][1] = scaled;
            croped = bmp.Clone(new Rectangle(118, 46, 43, 15), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 1.5), (int)(croped.Height * 1.5));
            planeSprites[0][2] = scaled;

            //F-14 TomCat
            //Should be corected
            planeSprites[1] = new Bitmap[3];
            bmp = new Bitmap(Resources.UNSquadronPlayer);
            croped = bmp.Clone(new Rectangle(8, 250, 50, 15), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 1.6), (int)(croped.Height * 1.6));
            planeSprites[1][0] = scaled;
            croped = bmp.Clone(new Rectangle(295, 270, 48, 17), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 1.6), (int)(croped.Height * 1.6));
            planeSprites[1][1] = scaled;
            croped = bmp.Clone(new Rectangle(125, 295, 47, 18), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 1.6), (int)(croped.Height * 1.6));
            planeSprites[1][2] = scaled;

            //A-10 ThuderBolt
            //Should be corected
            planeSprites[2] = new Bitmap[3];
            croped = bmp.Clone(new Rectangle(6, 526, 50, 15), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 1.5), (int)(croped.Height * 1.5));
            planeSprites[2][0] = scaled;
            croped = bmp.Clone(new Rectangle(308, 548, 48, 17), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 1.5), (int)(croped.Height * 1.5));
            planeSprites[2][1] = scaled;
            croped = bmp.Clone(new Rectangle(70, 587, 45, 23), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 1.5), (int)(croped.Height * 1.5));
            planeSprites[2][2] = scaled;

            bmp.Dispose();

            //Rockets
            rocketSprites[0] = new Bitmap[2];
            bmp = new Bitmap(Resources.rocket4);
            croped = new Bitmap(bmp, (int)(bmp.Width * 1.5F), (int)(bmp.Height * 1.1F));
            rocketSprites[0][0] = croped;
            bmp = new Bitmap(Resources.rocket5);
            croped = new Bitmap(bmp, (int)(bmp.Width * 1.5F), (int)(bmp.Height * 1.1F));
            rocketSprites[0][1] = croped;

            rocketSprites[1] = new Bitmap[2];
            bmp = new Bitmap(Resources.rocket2);
            croped = new Bitmap(bmp, (int)(bmp.Width * 1.0F), (int)(bmp.Height * 1.0F));
            rocketSprites[1][0] = croped;
            bmp = new Bitmap(Resources.rocket3);
            croped = new Bitmap(bmp, (int)(bmp.Width * 1.0F), (int)(bmp.Height * 1.0F));
            rocketSprites[1][1] = croped;

            rocketSprites[2] = new Bitmap[2];
            bmp = new Bitmap(Resources.rocket0);
            croped = new Bitmap(bmp, (int)(bmp.Width * 0.2F), (int)(bmp.Height * 0.2F));
            rocketSprites[2][0] = croped;
            bmp = new Bitmap(Resources.rocket1);
            croped = new Bitmap(bmp, (int)(bmp.Width * 0.2F), (int)(bmp.Height * 0.2F));
            rocketSprites[2][1] = croped;

            // Player Face Sprites
            bmp = new Bitmap(Resources.playerFace);
            croped = bmp.Clone(new Rectangle(0, 0, 66, 66), bmp.PixelFormat);
            playerFaceSprites[0] = croped;

            bmp = new Bitmap(Resources.playerFace);
            croped = bmp.Clone(new Rectangle(135, 0, 66, 66), bmp.PixelFormat);
            playerFaceSprites[1] = croped;

            bmp = new Bitmap(Resources.playerFace);
            croped = bmp.Clone(new Rectangle(199, 0, 66, 66), bmp.PixelFormat);
            playerFaceSprites[2] = croped;

            // Enemy Sprites

            //Explosion sprites
            explosionSprites[0] = new Bitmap[7];
            bmp = new Bitmap(Resources.exp10);
            scaled= new Bitmap(bmp, (int)(bmp.Width * 1.2F), (int)(bmp.Height * 1.2F));
            explosionSprites[0][0] = scaled;

            bmp = new Bitmap(Resources.exp11);
            scaled = new Bitmap(bmp, (int)(bmp.Width * 1.2F), (int)(bmp.Height * 1.2F));
            explosionSprites[0][1] = scaled;

            bmp = new Bitmap(Resources.exp12);
            scaled = new Bitmap(bmp, (int)(bmp.Width * 1.2F), (int)(bmp.Height * 1.2F));
            explosionSprites[0][2] = scaled;

            bmp = new Bitmap(Resources.exp13);
            scaled = new Bitmap(bmp, (int)(bmp.Width * 1.2F), (int)(bmp.Height * 1.2F));
            explosionSprites[0][3] = scaled;

            bmp = new Bitmap(Resources.exp14);
            scaled = new Bitmap(bmp, (int)(bmp.Width * 1.2F), (int)(bmp.Height * 1.2F));
            explosionSprites[0][4] = scaled;

            bmp = new Bitmap(Resources.exp15);
            scaled = new Bitmap(bmp, (int)(bmp.Width * 1.2F), (int)(bmp.Height * 1.2F));
            explosionSprites[0][5] = scaled;

            bmp = new Bitmap(Resources.exp16);
            scaled = new Bitmap(bmp, (int)(bmp.Width * 1.2F), (int)(bmp.Height * 1.2F));
            explosionSprites[0][6] = scaled;


            // Level Sprites

            // Level 1
            // public static Bitmap level1Sky;
            // public static Bitmap[] level1Ground = new Bitmap[6];

            //planeSprites[2] = new Bitmap[3];
            //croped = bmp.Clone(new Rectangle(6, 526, 50, 15), bmp.PixelFormat);
            //scaled = new Bitmap(croped, (int)(croped.Width * 1.5), (int)(croped.Height * 1.5));
            //planeSprites[2][0] = scaled;


            bmp = new Bitmap(Resources.level1);
            croped = bmp.Clone(new Rectangle(26, 12, 126, 414), bmp.PixelFormat);
            scaled = new Bitmap(croped, croped.Width, 600);
            Level1 = scaled;


            // Losho su isecheni, da se popraviv
            croped = bmp.Clone(new Rectangle(234, 34, 262, 152), bmp.PixelFormat);
            scaled = new Bitmap(croped, 800, 600);
            Level2[0] = scaled;

            croped = bmp.Clone(new Rectangle(507, 34, 262, 152), bmp.PixelFormat);
            scaled = new Bitmap(croped, 800, 600);
            Level2[1] = scaled;

            croped = bmp.Clone(new Rectangle(781, 34, 262, 152), bmp.PixelFormat);
            scaled = new Bitmap(croped, 800, 600);
            Level2[2] = scaled;

            croped = bmp.Clone(new Rectangle(1049, 34, 262, 152), bmp.PixelFormat);
            scaled = new Bitmap(croped, 800, 600);
            Level2[3] = scaled;

            croped = bmp.Clone(new Rectangle(1329, 34, 262, 152), bmp.PixelFormat);
            scaled = new Bitmap(croped, 800, 600);
            Level2[4] = scaled;

            croped = bmp.Clone(new Rectangle(1611, 34, 262, 152), bmp.PixelFormat);
            scaled = new Bitmap(croped, 800, 600);
            Level2[5] = scaled;
        }

    }
}
