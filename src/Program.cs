using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using SplashKitSDK;

namespace FirstFantasy
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                RunGame();
            }
            catch (Exception ex)
            {
                Console.WriteLine("crash: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
            }
        }
        public static void RunGame()
        {
            Window window = new Window("First Fantasy", 800, 600);
            GameState game = new GameState(window);

            while (!window.CloseRequested)
            {
                SplashKit.ProcessEvents();
                game.Tick();
                window.Refresh(60);
            }


        }
    }
}

