using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CarrierAirWing
{
    public class Settings
    {
        public static HighScore highScores { get; set; }
        public static int chosenPlane { get; set; }
        public static bool SOUNDS { get; set; }

        public static void Init()
        {
            highScores = ReadHighScore();
            chosenPlane = 0;
            if(Directory.Exists(@"sounds"))
                SOUNDS = true;
            else
                SOUNDS = false;
        }

        private static HighScore ReadHighScore()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            HighScore highScore = null;
            try
            {

                using (FileStream str = File.OpenRead(path + "\\hs_caw.hs"))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    try
                    {
                        highScore = (HighScore)bf.Deserialize(str);
                    }
                    catch (Exception)
                    {
                        return new HighScore();
                    }
                }

                return highScore;
            }
            catch (FileNotFoundException)
            {
                return new HighScore();
            }
        }

        public static void WriteHighScore()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            using (FileStream str = File.Open(path + "\\hs_caw.hs", FileMode.OpenOrCreate))
            {
                File.SetAttributes(path + "\\hs_caw.hs", File.GetAttributes(path + "\\hs_caw.hs") | FileAttributes.Hidden);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(str, highScores);
            }
        }
    }
}
