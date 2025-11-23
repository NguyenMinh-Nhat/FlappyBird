using CustomProgram;
using System;
using System.Linq;
using System.Windows;
using SplashKitSDK;

namespace MainProgram
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Window window = null;
            GameManager gameManager = null;
            
            try
            {
                
                window = new Window("Flappy Bird", 800, 600);
                gameManager = new GameManager(window);
                while (!window.CloseRequested)
                {
                    SplashKit.ProcessEvents();
                    
                    // Update game
                    gameManager.UpdateGame(0.016f);
                    
                    // Draw Game
                    SplashKit.ClearScreen();
                    gameManager.DrawGame();
                    SplashKit.RefreshScreen();
                    
                    // De,ay
                    SplashKit.Delay(16);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: "+ ex.Message);
            }

            finally
            {
                if (window != null)
                {
                    window.Close();
                }
            }
        }
    }
}