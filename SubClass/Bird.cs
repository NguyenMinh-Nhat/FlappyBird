using SplashKitSDK;

namespace CustomProgram
{
    public class Bird : GameObject
    {
        private Bitmap _character = null!; // Bird character Img

        public float flapForce = - 300f; // Initialize Flap Bird 

        // Physics property
        private float velocity = 0f;     // Current falling/rising speed
        private float gravity = 800f;    // How fast bird falls (pixels/second²)
        private float terminalVelocity = 500f; // Max falling speed
        
        private HealthSystem _health = null!;

        public Bird()
        {
            try
            {
                _character = SplashKit.LoadBitmap("BirdSprite", "bird-upflap.png");
                Health = new HealthSystem(5, 1.2f);

                this.X = 100f;
                this.Y = 300f;  
                this.Width = 40f;   // Collision Box 
                this.Height = 40f;  // Collision Box 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
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
            Y += velocity * deltaTime;
            if (Y < 0) Y = 0;

            if (Y > 550)
            {
                Y = 550;

                Health.Kill();
            }

            // Health Logic
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
            SplashKit.DrawBitmap(_character, X, Y);
        }

        public void Reset()
        {
            // Default Position
            this.X = 100f;
            this.Y = 300f;
            
            // Reset velocity
            this.velocity = 0f;

            // Reset Health 
            Health.Reset();
        }
    }
}                                                           