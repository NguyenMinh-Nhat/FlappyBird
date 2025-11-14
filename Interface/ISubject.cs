namespace CustomProgram
{
    public interface ISubject : IObserver
    {
        public void Attach();

        public void Detach();
        
        public void NotifyObservers();
    }
}