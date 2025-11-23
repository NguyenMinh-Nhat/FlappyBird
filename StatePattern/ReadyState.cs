using SplashKitSDK;
namespace CustomProgram
{
    public class ReadyState : IGameState
    {
        private GameManager gameManager;

        public ReadyState(GameManager context)
        {
            this.gameManager = context;
        }
        
        public void HandleInput()
        {
            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    // Chnage to Playing State
                    gameManager.ChangeState(new PlayingState(gameManager));
                }
        }

        public void Update(float deltaTime)
        {
            HandleInput();
            
            gameManager.Background.Update(deltaTime);
        }
        
        public void EnterState()
        {
            gameManager.Pipe.SpawnPipe();
        }
    }
}