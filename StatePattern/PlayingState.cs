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

        }

        public void Update(float deltaTime)
        {

        }
        
        public void EnterState()
        {
            
        }
    }
}