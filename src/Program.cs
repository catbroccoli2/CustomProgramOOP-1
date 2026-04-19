using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using SplashKitSDK;

namespace GameName
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("GameName", 800, 600); 
            SplashKit.OpenAudio();

            double PlayerX = 100;
            double PlayerY = 100;
            double speed = 3;

            //main game loop 
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                
                SplashKit.FillRectangle(Color.Red, PlayerX, PlayerY, 100, 100);
                
                if (SplashKit.KeyDown(KeyCode.AKey) || SplashKit.KeyDown(KeyCode.DownKey))
                {
                    PlayerY += speed;
                }else if (SplashKit.KeyDown(KeyCode.WKey) || SplashKit.KeyDown(KeyCode.UpKey))
                {
                    PlayerY -= speed;
                }else if (SplashKit.KeyDown(KeyCode.AKey) || SplashKit.KeyDown(KeyCode.LeftKey))
                {
                    PlayerX -= speed;
                }else if (SplashKit.KeyDown(KeyCode.DKey) || SplashKit.KeyDown(KeyCode.RightKey))
                {
                    PlayerX += speed;
                }

                SplashKit.RefreshScreen(60);
                


            } while (!window.CloseRequested);

            SplashKit.CloseAudio();
        }
    }
}
