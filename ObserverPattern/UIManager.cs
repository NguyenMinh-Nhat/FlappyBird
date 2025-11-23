using SplashKitSDK;
namespace CustomProgram
{
    public class UIManager : IObserver
    {
        private int _score;
        private int _health;
        private bool _isGameOver = false;
        private Font _gameFont;

        public UIManager()
        {
            try
            {
                _gameFont = SplashKit.LoadFont("GameFont", "FlappyBirdFont.ttf");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Font Error: " + ex.Message);
            }
            
        }
        public void Update(int score)
        {
            _score = score;
        }

        public void UpdateHealth(int health)
        {
            _health = health;
        }

        
        public void ShowGameOverScreen()
        {
            _isGameOver = true;
        }

        public void OnGameReset() 
        {
            _isGameOver = false;
            _score = 0;
        }

        public void OnGameOver()
        {
            ShowGameOverScreen(); 
        }
        
        public void Draw()
        {
            string scoreStr = _score.ToString(); 
            
            float textOffset = (_score < 10) ? 20 : 40; 
            
            float centerX = 400 ; 
            float centerY = 300; 

            SplashKit.DrawText(scoreStr, Color.WhiteSmoke, "GameFont", 60, centerX - 35, centerY - 200);
            

            // Draw Health 
            
            float hpX = 10; 
            float hpY = 20;

            SplashKit.DrawText($"HP:", Color.WhiteSmoke, "GameFont", 20, hpX, hpY); 
            
            for (int i = 0; i < _health; i++)
            {
                float circleX = 60 + (i * 30); 
                float circleY = hpY + 8; 

                SplashKit.FillCircle(Color.Red, circleX, circleY, 10);
                SplashKit.DrawCircle(Color.White, circleX, circleY, 10);
            }

            // GameOver UI
            if (_isGameOver)
            {
                SplashKit.FillRectangle(Color.RGBAColor(0, 0, 0, 150), 0, 0, 800, 600);
                
                SplashKit.FillRectangle(Color.White, centerX - 150, centerY - 100, 300, 200);
                SplashKit.DrawRectangle(Color.Black, centerX - 150, centerY - 100, 300, 200);

                SplashKit.DrawText("GAME OVER", Color.Red, "GameFont", 40, centerX - 120, centerY - 60);
                SplashKit.DrawText($"Final Score: {_score}", Color.Black, "GameFont", 20, centerX - 60, centerY + 10);
                SplashKit.DrawText("Press SPACE to Restart", Color.Blue, "GameFont", 15, centerX - 80, centerY + 50);
            }
        }
    }
}