namespace CustomProgram
{
    public interface ISubject
    {
        void Attach(IObserver obs);

        void Detach(IObserver obs);
        
        void NotifyScoreChanged(); 
        void NotifyHealthChanged();
        
        void NotifyGameReset();
        void NotifyGameOver();
    }
}