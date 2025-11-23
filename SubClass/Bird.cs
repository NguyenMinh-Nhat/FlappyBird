using SplashKitSDK;

namespace CustomProgram
{
    public class Bird : GameObject
    {
        private Bitmap _character; // Bird character Img

        public float flapForce = - 300f; // Initialize Flap Bird 

        // Physics property
        private float velocity = 0f;     // Current falling/rising speed
        private float gravity = 800f;    // How fast bird falls (pixels/second²)
        private float terminalVelocity = 500f; // Max falling speed
        
        // Position
        private float x = 100f;  // Default Bird's X position
        private float y = 300f;  // Default Bird's Y position 

        // Hitbox
        private float width = 40f;
        private float height = 40f;

        private Rectangle _collisionBox;
        private HealthSystem _health;

        public Bird()
        {
            try
            {
                _character = SplashKit.LoadBitmap("BirdSprite", "bird-upflap.png");
                Health = new HealthSystem(5, 1.2f);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        
        public Rectangle CollisionBox
        {
            get
            {
                return _collisionBox = SplashKit.RectangleFrom(x, y, width, height);
            }
        }

        public float X
        {
            get
            {
                return x;
            }
        }

        public float Y
        {
            get
            {
                return y;
            }
        }

        // Get Health 
        public HealthSystem Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
            }
        }
        public void Flap()
        {
            // Reset velocity 
            velocity = flapForce;       
        }

        public override void Update(float deltaTime)
        {

            // Fall logic 
            velocity += gravity * deltaTime;
            if (velocity > terminalVelocity) velocity = terminalVelocity;
            y += velocity * deltaTime;
            if (y < 0) y = 0;

            if (y > 550)
            {
                y = 550;

                Health.Kill();
            }

            // 
            Health.Update(deltaTime);
            
        }

        public override void Draw()
        {
            // Inmune animation
            if (Health.IsInvincible)
            {
                // every 15 frame draw 5 frame
                if (SplashKit.Rnd(0, 15) < 5) return;
            }
            // SplashKit.FillRectangle(Color.Blue, x,y,width,height);
            SplashKit.DrawBitmap(_character, x, y);
        }

        public void Reset()
        {
            // Default Position
            this.x = 100f;
            this.y = 300f;
            
            // Reset velocity
            this.velocity = 0f;

            Health.Reset();
        }
    }
}                                                           