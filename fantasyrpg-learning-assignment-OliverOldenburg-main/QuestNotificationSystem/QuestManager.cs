using System.Collections.Generic;

namespace QuestNotificationSystem
{
    public class QuestManager : ISubject
    {
        private List<Observer> observers;
        private string questStatus;

        public QuestManager()
        {
            observers = new List<Observer>();
        }

        public void Subscribe(Observer observer)
        {
            observers.Add(observer);
            Console.WriteLine($"Observer added: {observer.GetType().Name}");
        }

        public void Unsubscribe(Observer observer)
        {
            observers.Remove(observer);
            Console.WriteLine($"Observer removed: {observer.GetType().Name}");
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(questStatus);
            }
        }

        public void ChangeQuestStatus(string status)
        {
            questStatus = status;
            Console.WriteLine($"Quest status updated to: {status}");
            NotifyObservers();
        }
    }
}