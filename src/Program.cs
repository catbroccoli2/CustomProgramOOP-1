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
            catch(Exception ex)
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

        Player player = new Player(400, 400, 3);

        List<Entity> entities = new List<Entity>();
        entities.Add(player);
        entities.Add(new Enemy("Goblin", 100, 100, 30, 1.5, player));

        while (!window.CloseRequested)
        {
            SplashKit.ProcessEvents();


            foreach (Entity e in entities)
                {
                    e.Update();
                }

            

            foreach (Entity e in entities)
                {
                    if (e is Enemy enemy && enemy.IsActive)
                    {
                        if (player.CollidesWith(enemy))
                        {
                            Console.WriteLine($"Player collided with: {enemy.Name}");
                        }
                    }
                }
            window.Clear(Color.White);

            foreach (Entity e in entities)
                {
                    e.Draw();
                }
            
            window.Refresh(60);
        }
    }
}
}
