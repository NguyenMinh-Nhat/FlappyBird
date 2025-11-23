using SplashKitSDK;
namespace CustomProgram
{
    public class Pipe : GameObject, IPipe
    {
        private float speed = 200f;
        private float _width = 50f;
        private float _height = 300f;
        private float x;
        private float y;
        private bool isScored = false;
        private Bitmap _pipeIMG;
        private Bitmap _pipeFlipIMG;

        // Default constructor
        // public Pipe() : this(600f, 0f, 200f)
        // {
        // }
        
        // Constructor
        public Pipe(float x, float y, float speed)
        {
            this.X = x;          // Use properties instead of fields
            this.Y = y;
            this.Speed = speed;
            _pipeIMG = SplashKit.LoadBitmap("PipeIMG", "pipe-green.png");
            _pipeFlipIMG = SplashKit.LoadBitmap("PipeFlipIMG", "pipe-greenflip.png");
        }
        public bool IsScored
        {
            get
            {
                return isScored;
            }
            set
            {
                isScored = value;
            }
        }

        // Position properties 
        public float X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public float Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        // Size properties
        public float Width 
        { 
            get { return _width; } 
            set { _width = value; } 
        }
        
        public float Height 
        { 
            get { return _height; } 
            set { _height = value; } 
        }

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }


        // Return current pos
        public Rectangle CollisionBox
        {
            get
            {
                return SplashKit.RectangleFrom(X, Y, Width, Height);
            }
        }



        public override void Update(float deltaTime)
        {
            // Move pipe to left
            Move(deltaTime);
        }

        // Draw Pipe
        public override void Draw()
        {
            Bitmap currentBitmap;
            
            if (Y == 0) // Upper Pipe
            {
                currentBitmap = _pipeFlipIMG;
            }
            else // Lower Pipe 
            {
                currentBitmap = _pipeIMG;
            }

            // Calculate X
            double scaleX = _width / currentBitmap.Width;

            // Calculate height to cut
            double sourceHeight = _height;
            if (sourceHeight > currentBitmap.Height) sourceHeight = currentBitmap.Height;

            // Cut and Scale Img
            DrawingOptions opts = SplashKit.OptionScaleBmp(scaleX, 1.0);

            // Cut Img Logic
            if (Y == 0) // Upper Pipe
            {
                double startY = currentBitmap.Height - sourceHeight;
                
                opts = SplashKit.OptionPartBmp(0, startY, currentBitmap.Width, sourceHeight, opts);
            }
            else // Lower Pipe
            {
                // Cut from top to down
                opts = SplashKit.OptionPartBmp(0, 0, currentBitmap.Width, sourceHeight, opts);
            }

            // Draw
            SplashKit.DrawBitmap(currentBitmap, X, Y, opts);
        }

        // Move command
        public void Move(float deltaTime)
        {
            X -= Speed * deltaTime;  
        }
    }
}