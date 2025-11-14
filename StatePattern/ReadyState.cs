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

        }

        public void Update(float deltaTime)
        {

        }
        
        public void EnterState()
        {
            
        }
    }
}