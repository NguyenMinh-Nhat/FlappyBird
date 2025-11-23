using SplashKitSDK;
namespace CustomProgram
{
    public class GameOverState : IGameState
    {
        private GameManager gameManager;

        public GameOverState(GameManager context)
        {
            this.gameManager = context;
        }
        
        public void HandleInput()
        {
            if (SplashKit.KeyTyped(KeyCode.SpaceKey) || SplashKit.KeyTyped(KeyCode.UpKey))
            {
                // Reset score
                gameManager.ResetGame();

                // change state (Ready State)
                gameManager.ChangeState(new ReadyState(gameManager));
       
            }
        }

        public void Update(float deltaTime)
        {   
            HandleInput();
        }
        
        public void EnterState()
        {
            Console.WriteLine("Entered Game Over State");
        }
    }
}