using SplashKitSDK;
using System;
namespace CustomProgram
{
    public class GameManager : ISubject
    {
        private int score;
        private IGameState currentState;
        private List<IObserver> observers;
        private PipeManager pipeManager;
        private Bird bird;
        private OrbManager orbManager;
        private UIManager uiManager;
        private Background background;
        private SoundManager soundManager;

        // Constructor 
        public GameManager(Window window)
        {
            try {
                this.observers = new List<IObserver>(); // Initialize Observer
                
                this.pipeManager = new PipeManager(); // Initialize PipeManager
                this.orbManager = new OrbManager(pipeManager); // Initilize OrbManager
                this.background = new Background(window); // Initilize Background
                

                // Initilize Default State (Ready State)
                this.currentState = new ReadyState(this);
                
                this.bird = new Bird(); // Initialize Bird
                this.currentState.EnterState();
                
                this.score = 0;     // Initilize Score
            }
            catch (Exception ex)
            {
                Console.WriteLine("Gamemanager Error: " + ex.Message);
                throw;
            }

            // Sound Manager
            try 
            {
                this.soundManager = new SoundManager();
                this.Attach(soundManager);
                soundManager.StartMusic();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot Load Sound: " + ex.Message);
                
            }

            // Ui Manager   
            try
            {
                this.uiManager = new UIManager(); // Initialize UI

                // Observer Subcriber
                this.Attach(uiManager);   
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load ui: " + ex.Message);
            }

            NotifyHealthChanged(); // Update Health In UI
            NotifyScoreChanged();  // Update Score In UI
        }

        public SoundManager SoundManager
        {
            get
            {
                return soundManager;
            }
        }
        public OrbManager OrbManager
        {
            get
            {
                return orbManager;
            }
        }

        public Bird Bird
        {
            get
            {
                return bird;
            }
            
        }
        
        public PipeManager Pipe
        {
            get
            {
                return pipeManager;
            }
        }

        public Background Background
        {
            get
            {
                return background;
            }
        }
        public int Score
        {
            get
            {
                return score;
            }
        }

        // Implement ISubject constract
        public void Attach(IObserver obs)
        {
            this.observers.Add(obs);
        }

        public void Detach(IObserver obs)
        {
            this.observers.Remove(obs);
        }

        // Notify Score
        public void NotifyScoreChanged()
        {
            foreach (IObserver obs in observers) obs.Update(score);
        }

        // Notify Health
        public void NotifyHealthChanged()
        {
            foreach (IObserver obs in observers) obs.UpdateHealth(bird.Health.CurrentHealth);
        }

        // Notify Reset
        public void NotifyGameReset()
        {
            foreach (IObserver obs in observers) obs.OnGameReset();
        }

        // Notify GameOver
        public void NotifyGameOver()
        {
            foreach (IObserver obs in observers) obs.OnGameOver();
        }

        public void IncrementScore(int newScore)
        {
            score += newScore;
            NotifyScoreChanged(); 
            soundManager.Update(newScore);
        }

        public void BirdTakeDamage(int damage)
        {
            bird.Health.TakeDamage(damage);
            NotifyHealthChanged(); 
        }

        public void ResetGame() 
        {
            score = 0;

            // Reset Game Over UI
            NotifyGameReset(); 

            // Reset Bird, Pipes, Orbs
            bird.Reset(); 
            pipeManager.Reset();
            orbManager.Reset();

            // Update UI
            NotifyHealthChanged(); // UI Draw -> 5 health orb
            NotifyScoreChanged(); // UI Draw -> 0 score
        }

        public void ChangeState(IGameState newState)
        {
            this.currentState = newState;

            if (newState is GameOverState)
            {
                NotifyGameOver(); 
            }
        }
        

        public void CheckPipeCollisions()
        {
            // Already Immune -> skip checking
            if (bird.Health.IsInvincible || bird.Health.IsDead) return;

            foreach (Pipe pipe in pipeManager.ListPipes)
            {
                if (SplashKit.RectanglesIntersect(bird.CollisionBox, pipe.CollisionBox))
                {
                    Console.WriteLine("Collision Detected.");
                    
                    // Minus Bird Health + Notify UI
                    BirdTakeDamage(1); 
                    
                    return; 
                }
            }
        }

        public void CheckOrbCollision()
        {
            // Reverse For loop
            for (int i = OrbManager.Orbs.Count - 1; i >= 0; i--)
            {
                Orb orb = OrbManager.Orbs[i];

                if (SplashKit.RectanglesIntersect(Bird.CollisionBox, orb.CollisionBox))
                {
                    // Trigger Effect
                    orb.OnCollected();
                    ApplyOrbEffect(orb.EffectType);

                    // Play Sound
                    soundManager.PlayOrbSound();

                    // Remove orb at index i
                    OrbManager.Orbs.RemoveAt(i);
                }
            }
        }

        public void ApplyOrbEffect(OrbEffectType type)
        {
            switch (type)
            {
                // Health Orb
                case OrbEffectType.Health:
                    Bird.Health.Heal(1);
                    NotifyHealthChanged();
                    Console.WriteLine("Health Up!");
                    break;

                // Imune
                case OrbEffectType.Imune:
                    Bird.Health.ActivateInvincibility(5f);  // 5 sec imune
                    Console.WriteLine("Immune Activated!");
                    break;

                // Point
                case OrbEffectType.Point:
                    IncrementScore(2); // + 2 point for point orb
                    break;
                
            }
        }
        
        public void ProcessInput() {
            currentState.HandleInput();
        }

        public void UpdateGame(float deltaTime)
        {
            // let currentState handle
            if (currentState != null)
            {
                currentState.Update(deltaTime);
            }
        }

        public void DrawGame()
        {
            background.Draw();
            pipeManager.DrawPipes();
            orbManager.Draw();
            bird.Draw();
            uiManager.Draw();
            // Console.WriteLine("Bird Score:" + score);
        }
    
    }
}