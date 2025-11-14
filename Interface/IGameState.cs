namespace CustomProgram
{
    public interface IGameState
    {
        void HandleInput();

        void Update(float deltaTime);

        void EnterState();
    }
}