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

        }

        public void Update(float deltaTime)
        {

        }
        
        public void EnterState()
        {
            
        }
    }
}