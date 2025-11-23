using System.Reflection.Metadata;
using SplashKitSDK;
namespace CustomProgram
{
    public class PlayingState : IGameState
    {
        private GameManager gameManager;
        
            
        public PlayingState(GameManager context)
        {
            this.gameManager = context;
        }
        
        public void HandleInput()
        {
            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                gameManager.Bird.Flap();
                gameManager.SoundManager.PlayJump();
            }
        }

        public void IncrementScore()
        {
        foreach (Pipe pipe in gameManager.Pipe.ListPipes)
            {
                if (!pipe.IsScored && gameManager.Bird.X > pipe.X + pipe.Width && pipe.Y == 0)
                {
                    // Set to true if pos bird are passing pipe
                    pipe.IsScored = true;
                    
                    // notify gamemanager to increase score
                    gameManager.IncrementScore(1);
                    Console.WriteLine($"Scored! New score: {gameManager.Score}");
                    break;
                }
            }
        }

        public void Update(float deltaTime)
        {
            HandleInput();

            gameManager.Bird.Update(deltaTime);
            gameManager.Pipe.UpdatePipes(deltaTime);
            
            gameManager.OrbManager.Update(deltaTime);
            gameManager.Background.Update(deltaTime);
            
            gameManager.CheckCollisions();

            
            
            gameManager.CheckOrbCollision();
            
            // Increase score
            IncrementScore();

            // Bird Dead? -> Notify GameOver State
            if (gameManager.Bird.Health.IsDead)
            {
                // Play die Sound
                gameManager.SoundManager.BirdDie();

                // Change to Over State
                gameManager.ChangeState(new GameOverState(gameManager));
                
            }

            gameManager.Background.Update(deltaTime);
        }
        
        public void EnterState()
        {
            Console.WriteLine("Game Start");
            
        }
    }
}