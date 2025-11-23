using SplashKitSDK;

namespace CustomProgram
{
    public class Background
    {
        private Bitmap _bgBitmap;
        private float _x1, _x2; 
        private float _scrollSpeed = 50f;
        private Window _gameWindow; 

        public Background(Window gameWindow)
        {
            _gameWindow = gameWindow;
            
            try 
            {
                // Load img
                _bgBitmap = SplashKit.LoadBitmap("Background", "FlappyBirdBackground.png");
                
                Console.WriteLine($"Load Img successfully! Dimension: {_bgBitmap.Width}x{_bgBitmap.Height}");
            }
            catch (Exception ex)
            {
                // Fall Back
                Console.WriteLine($"Background Error: {ex.Message}");

                _bgBitmap = SplashKit.CreateBitmap("DummyBG", 800, 600);
                SplashKit.ClearBitmap(_bgBitmap, Color.Green); 
            }

            // Back up method

            _x1 = 0;
            
            
            float scaleFactor = (float)_gameWindow.Height / _bgBitmap.Height;
            _x2 = _bgBitmap.Width * scaleFactor; 
        }

        public void Update(float deltaTime)
        {

            float scaleFactor = (float)_gameWindow.Height / _bgBitmap.Height;
            float actualWidth = _bgBitmap.Width * scaleFactor;

            _x1 -= _scrollSpeed * deltaTime;
            _x2 -= _scrollSpeed * deltaTime;

            // Combine Image
            if (_x1 <= -actualWidth) _x1 = _x2 + actualWidth;
            if (_x2 <= -actualWidth) _x2 = _x1 + actualWidth;
        }

        public void Draw()
        {
            double scaleVal = (double)_gameWindow.Height / _bgBitmap.Height;
            DrawingOptions opts = SplashKit.OptionScaleBmp(scaleVal, scaleVal);

            // Draw Img
            SplashKit.DrawBitmap(_bgBitmap, _x1, 0, opts);
            SplashKit.DrawBitmap(_bgBitmap, _x2, 0, opts);
        }
    }
}