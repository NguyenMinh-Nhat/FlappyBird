using SplashKitSDK;
namespace CustomProgram
{
    public class GameManager
    {
        private int score;
        private IGameState currentState;
        private List<IObserver> observers;

        // Constructor 
        public GameManager()
        {
            this.observers = new List<IObserver>();
            this.currentState = new ReadyState(this);
            this.currentState.EnterState();
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

        public void NotifyObservers()
        {
            // Logic cốt lõi của Observer: Duyệt qua observers và gọi Update()
            // Cần truyền điểm số vào phương thức Update(score) của IObserver
            foreach (var obs in this.observers)
            {
                // Giả sử điểm số được lấy từ thuộc tính 'score'
                obs.Update(this.score); 
            }
        }

        public void IncrementScore()
        {
            this.score++;
            NotifyObservers(); // Kích hoạt thông báo sau khi tăng điểm
        }

        public void ApplyOrbEffect()
        {

        }
        
        public void ChangeState(IGameState gameState)
        {
            
        }
        
        public void UpdateGame(float deltaTime){
            currentState.Update(deltaTime);
        }

        public void RunGameLoop()
        {
            while (!SplashKit.WindowCloseRequested("Flappy Bird"))
            {
                SplashKit.ProcessEvents();
                
                // Calculate delta time
                float deltaTime = SplashKit.TimerTicks("gameTimer") / 1000.0f;
                SplashKit.ResetTimer("gameTimer");
                
                // Update game
                this.UpdateGame(deltaTime);
                
                // Render
                SplashKit.RefreshScreen(60); // 60 FPS
            }
        }
    }
}