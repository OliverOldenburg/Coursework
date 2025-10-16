namespace QuestNotificationSystem
{
    public interface ISubject
    {
        void Subscribe(Observer observer);
        void Unsubscribe(Observer observer);
        void NotifyObservers();
    }
}