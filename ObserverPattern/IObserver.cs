namespace CustomProgram
{
    public interface IObserver
    {
        void Update(int newScore); // Update score to ui
        void UpdateHealth(int currentHealth); // Update health to ui
        void OnGameReset(); // Reset State
        void OnGameOver(); // Game Over State
    }
}