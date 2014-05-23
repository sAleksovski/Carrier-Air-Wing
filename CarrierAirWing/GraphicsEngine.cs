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
        public static Bitmap[][] enemySprites = new Bitmap[27][];
        public static Bitmap[] playerFaceSprites = new Bitmap[3];
        public static Bitmap[][] explosionSprites = new Bitmap[2][];

        public static Bitmap Level1;
        public static Bitmap Level2;
        public static Bitmap[] Level3 = new Bitmap[5];
        
        public static Random randomizer;

        public static void Init()
        {
            //Random number generator
            randomizer = new Random();

            // Player Sprites
            // F-20 TigerShark
            // This are 100% correct
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

            // F-14 TomCat
            // 100% correcet
            planeSprites[1] = new Bitmap[3];
            bmp = new Bitmap(Resources.UNSquadronPlayer);
            croped = bmp.Clone(new Rectangle(10, 253, 47, 11), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 1.6), (int)(croped.Height * 1.6));
            planeSprites[1][0] = scaled;
            croped = bmp.Clone(new Rectangle(297, 272, 47, 12), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 1.6), (int)(croped.Height * 1.6));
            planeSprites[1][1] = scaled;
            croped = bmp.Clone(new Rectangle(127, 297, 47, 16), bmp.PixelFormat);
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



            //Rockets
            rocketSprites[0] = new Bitmap[2];
            bmp = new Bitmap(Resources.rocket4);
            croped = new Bitmap(bmp, (int)(bmp.Width * 2F), (int)(bmp.Height * 1.5F));
            rocketSprites[0][0] = croped;
            bmp = new Bitmap(Resources.rocket5);
            croped = new Bitmap(bmp, (int)(bmp.Width * 2F), (int)(bmp.Height * 1.5F));
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
            // Green Helis
            bmp = new Bitmap(Resources.enemies);
            enemySprites[0] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(0, 8, 31, 10), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.0), (int)(croped.Height * 2.0));
            enemySprites[0][0] = scaled;
            croped = bmp.Clone(new Rectangle(37, 8, 31, 10), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.0), (int)(croped.Height * 2.0));
            enemySprites[0][1] = scaled;

            enemySprites[1] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(77, 2, 29, 16), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.0), (int)(croped.Height * 2.0));
            enemySprites[1][0] = scaled;
            croped = bmp.Clone(new Rectangle(110, 2, 29, 16), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.0), (int)(croped.Height * 2.0));
            enemySprites[1][1] = scaled;

            enemySprites[2] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(144, 2, 29, 16), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.0), (int)(croped.Height * 2.0));
            enemySprites[2][0] = scaled;
            croped = bmp.Clone(new Rectangle(177, 2, 29, 16), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.0), (int)(croped.Height * 2.0));
            enemySprites[2][1] = scaled;

            enemySprites[3] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(215, 8, 31, 10), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.0), (int)(croped.Height * 2.0));
            enemySprites[3][0] = scaled;
            croped = bmp.Clone(new Rectangle(252, 8, 31, 10), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.0), (int)(croped.Height * 2.0));
            enemySprites[3][1] = scaled;

            // Red Helis
            enemySprites[4] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(0, 30, 31, 10), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.0), (int)(croped.Height * 2.0));
            enemySprites[4][0] = scaled;
            croped = bmp.Clone(new Rectangle(37, 30, 31, 10), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.0), (int)(croped.Height * 2.0));
            enemySprites[4][1] = scaled;

            enemySprites[5] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(77, 24, 29, 16), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.0), (int)(croped.Height * 2.0));
            enemySprites[5][0] = scaled;
            croped = bmp.Clone(new Rectangle(110, 24, 29, 16), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.0), (int)(croped.Height * 2.0));
            enemySprites[5][1] = scaled;

            enemySprites[6] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(144, 24, 29, 16), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.0), (int)(croped.Height * 2.0));
            enemySprites[6][0] = scaled;
            croped = bmp.Clone(new Rectangle(177, 24, 29, 16), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.0), (int)(croped.Height * 2.0));
            enemySprites[6][1] = scaled;

            enemySprites[7] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(215, 30, 31, 10), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.0), (int)(croped.Height * 2.0));
            enemySprites[7][0] = scaled;
            croped = bmp.Clone(new Rectangle(252, 30, 31, 10), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.0), (int)(croped.Height * 2.0));
            enemySprites[7][1] = scaled;

            // Blue Planes
            enemySprites[8] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(33, 103, 30, 14), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.0), (int)(croped.Height * 2.0));
            enemySprites[8][0] = scaled;
            enemySprites[8][1] = scaled;

            enemySprites[9] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(68, 103, 30, 14), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.0), (int)(croped.Height * 2.0));
            enemySprites[9][0] = scaled;
            enemySprites[9][1] = scaled;

            enemySprites[10] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(101, 103, 30, 9), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.0), (int)(croped.Height * 2.0));
            enemySprites[10][0] = scaled;
            enemySprites[10][1] = scaled;

            enemySprites[11] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(0, 103, 30, 9), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.0), (int)(croped.Height * 2.0));
            enemySprites[11][0] = scaled;
            enemySprites[11][1] = scaled;

            // Dark Green Planes
            enemySprites[18] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(32, 54, 30, 17), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.2), (int)(croped.Height * 2.2));
            enemySprites[18][0] = scaled;
            enemySprites[18][1] = scaled;

            enemySprites[19] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(67, 62, 29, 9), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.2), (int)(croped.Height * 2.2));
            enemySprites[19][0] = scaled;
            enemySprites[19][1] = scaled;

            enemySprites[20] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(103, 62, 29, 9), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.2), (int)(croped.Height * 2.2));
            enemySprites[20][0] = scaled;
            enemySprites[20][1] = scaled;

            enemySprites[21] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(137, 54, 30, 17), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.2), (int)(croped.Height * 2.2));
            enemySprites[21][0] = scaled;
            enemySprites[21][1] = scaled;


            // Green Planes
            enemySprites[12] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(0, 83, 26, 15), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.6), (int)(croped.Height * 2.6));
            enemySprites[12][0] = scaled;
            enemySprites[12][1] = scaled;

            enemySprites[13] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(30, 86, 26, 10), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.6), (int)(croped.Height * 2.6));
            enemySprites[13][0] = scaled;
            enemySprites[13][1] = scaled;

            enemySprites[14] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(59, 85, 27, 8), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.6), (int)(croped.Height * 2.6));
            enemySprites[14][0] = scaled;
            enemySprites[14][1] = scaled;

            enemySprites[15] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(89, 85, 26, 8), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.6), (int)(croped.Height * 2.6));
            enemySprites[15][0] = scaled;
            enemySprites[15][1] = scaled;

            enemySprites[16] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(119, 86, 26, 10), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.6), (int)(croped.Height * 2.6));
            enemySprites[16][0] = scaled;
            enemySprites[16][1] = scaled;

            enemySprites[17] = new Bitmap[2];
            croped = bmp.Clone(new Rectangle(149, 83, 26, 15), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 2.6), (int)(croped.Height * 2.6));
            enemySprites[17][0] = scaled;
            enemySprites[17][1] = scaled;

            // Large Enemy Plane
            enemySprites[22] = new Bitmap[3];
            croped = bmp.Clone(new Rectangle(0, 121, 107, 39), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 1.3), (int)(croped.Height * 1.3));
            enemySprites[22][0] = scaled;
            enemySprites[22][1] = scaled;
            croped = bmp.Clone(new Rectangle(124, 121, 107, 39), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 1.3), (int)(croped.Height * 1.3));
            enemySprites[22][2] = scaled;

            // Boss 1
            enemySprites[23] = new Bitmap[3];
            bmp = new Bitmap(Resources.boss1);
            croped = bmp.Clone(new Rectangle(6, 5, 139, 79), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 1.5), (int)(croped.Height * 1.5));
            enemySprites[23][0] = enemySprites[23][1] = scaled;
            croped = bmp.Clone(new Rectangle(154, 5, 139, 79), bmp.PixelFormat);
            scaled = new Bitmap(croped, (int)(croped.Width * 1.5), (int)(croped.Height * 1.5));
            enemySprites[23][2] = scaled;


            // Explosion sprites
            // Type 1
            explosionSprites[0] = new Bitmap[7];
            bmp = new Bitmap(Resources.exp10);
            scaled = new Bitmap(bmp, (int)(bmp.Width * 2.0F), (int)(bmp.Height * 2.0F));
            explosionSprites[0][0] = scaled;

            bmp = new Bitmap(Resources.exp11);
            scaled = new Bitmap(bmp, (int)(bmp.Width * 2.0F), (int)(bmp.Height * 2.0F));
            explosionSprites[0][1] = scaled;

            bmp = new Bitmap(Resources.exp12);
            scaled = new Bitmap(bmp, (int)(bmp.Width * 2.0F), (int)(bmp.Height * 2.0F));
            explosionSprites[0][2] = scaled;

            bmp = new Bitmap(Resources.exp13);
            scaled = new Bitmap(bmp, (int)(bmp.Width * 2.0F), (int)(bmp.Height * 2.0F));
            explosionSprites[0][3] = scaled;

            bmp = new Bitmap(Resources.exp14);
            scaled = new Bitmap(bmp, (int)(bmp.Width * 2.0F), (int)(bmp.Height * 2.0F));
            explosionSprites[0][4] = scaled;

            bmp = new Bitmap(Resources.exp15);
            scaled = new Bitmap(bmp, (int)(bmp.Width * 2.0F), (int)(bmp.Height * 2.0F));
            explosionSprites[0][5] = scaled;

            bmp = new Bitmap(Resources.exp16);
            scaled = new Bitmap(bmp, (int)(bmp.Width * 2.0F), (int)(bmp.Height * 2.0F));
            explosionSprites[0][6] = scaled;

            // Type 2
            explosionSprites[1] = new Bitmap[4];
            bmp = new Bitmap(Resources.exp20);
            scaled = new Bitmap(bmp, (int)(bmp.Width * 2.0F), (int)(bmp.Height * 2.0F));
            explosionSprites[1][0] = scaled;

            bmp = new Bitmap(Resources.exp21);
            scaled = new Bitmap(bmp, (int)(bmp.Width * 2.0F), (int)(bmp.Height * 2.0F));
            explosionSprites[1][1] = scaled;

            bmp = new Bitmap(Resources.exp22);
            scaled = new Bitmap(bmp, (int)(bmp.Width * 2.0F), (int)(bmp.Height * 2.0F));
            explosionSprites[1][2] = scaled;

            bmp = new Bitmap(Resources.exp23);
            scaled = new Bitmap(bmp, (int)(bmp.Width * 2.0F), (int)(bmp.Height * 2.0F));
            explosionSprites[1][3] = scaled;


            // Level Sprites
            // Level 1
            bmp = new Bitmap(Resources.level1);
            croped = bmp.Clone(new Rectangle(26, 12, 126, 414), bmp.PixelFormat);
            scaled = new Bitmap(croped, croped.Width, 600);
            Level1 = scaled;

            // Level 2
            bmp = new Bitmap(Resources.level2);
            scaled = new Bitmap(bmp, bmp.Width, 600);
            Level2 = scaled;

            // Level 3
            bmp = new Bitmap(Resources.level1);
            croped = bmp.Clone(new Rectangle(233, 33, 262, 152), bmp.PixelFormat);
            scaled = new Bitmap(croped, 800, 600);
            Level3[0] = scaled;

            croped = bmp.Clone(new Rectangle(507, 33, 262, 152), bmp.PixelFormat);
            scaled = new Bitmap(croped, 800, 600);
            Level3[1] = scaled;

            croped = bmp.Clone(new Rectangle(779, 33, 262, 152), bmp.PixelFormat);
            scaled = new Bitmap(croped, 800, 600);
            Level3[2] = scaled;

            croped = bmp.Clone(new Rectangle(1048, 33, 262, 152), bmp.PixelFormat);
            scaled = new Bitmap(croped, 800, 600);
            Level3[3] = scaled;

            croped = bmp.Clone(new Rectangle(1328, 33, 262, 152), bmp.PixelFormat);
            scaled = new Bitmap(croped, 800, 600);
            Level3[4] = scaled;

            
        }

    }
}
