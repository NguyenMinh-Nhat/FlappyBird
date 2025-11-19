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
            Window window = new Window("Flappy Bird", 800, 600);
            GameManager gameManager = new GameManager();
            
            while (!window.CloseRequested)
            {
                SplashKit.ProcessEvents();
                
                // Update game with proper delta time
                gameManager.UpdateGame(SplashKit.TimerTicks("frameTimer") / 1000.0f);
                SplashKit.ResetTimer("frameTimer");
            }
        }
    }
}