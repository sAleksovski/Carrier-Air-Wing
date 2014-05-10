using CarrierAirWing.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace CarrierAirWing
{

    static class SoundEngine
    {
        static WindowsMediaPlayer backgroundPlayer;
        static WindowsMediaPlayer explosionPlayer;
        static WindowsMediaPlayer[] rocketPlayer;

        public static void Init()
        {
            backgroundPlayer = new WindowsMediaPlayer();
            rocketPlayer = new WindowsMediaPlayer[15];
            explosionPlayer = new WindowsMediaPlayer();

            backgroundPlayer.settings.volume = 30;
            backgroundPlayer.settings.autoStart = false;
            backgroundPlayer.settings.setMode("loop", true);

            explosionPlayer.settings.autoStart = false;

            for (int i = 0; i < rocketPlayer.Length; i++)
            {
                rocketPlayer[i] = new WindowsMediaPlayer();
                rocketPlayer[i].settings.autoStart = false;
                rocketPlayer[i].URL = @"sounds\rockets\rocket1.mp3";
                rocketPlayer[i].settings.volume = 50;
            }
        }

        public static void PlayBackgroundMusic(String fileName)
        {
            backgroundPlayer.URL = fileName;
            backgroundPlayer.settings.volume = 30;
            backgroundPlayer.settings.setMode("loop", true);
            backgroundPlayer.controls.play();
        }

        public static void StopBackgroundMusic()
        {
            backgroundPlayer.controls.stop();
        }



        public static void PlayRocketSound()
        {
            foreach (WindowsMediaPlayer wmp in rocketPlayer)
            {
                if (wmp.playState != WMPPlayState.wmppsPlaying)
                {
                    wmp.controls.play();
                    return;
                }
            }

        }

        public static void StopRocketSound()
        {
            foreach (WindowsMediaPlayer wmp in rocketPlayer)
            {
                wmp.controls.stop();
            }
        }



        public static void PlayExplosionSound(String fileName)
        {
            explosionPlayer = new WindowsMediaPlayer();
            explosionPlayer.URL = fileName;
            explosionPlayer.controls.play();
        }

        public static void StopExplosionSound()
        {
            explosionPlayer.controls.stop();
        }
    }
}
