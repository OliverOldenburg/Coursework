namespace QuestNotificationSystem
{
    public class PlayerCharacter : Observer
    {
        public string Name { get; private set; }

        public PlayerCharacter(string name)
        {
            Name = name;
        }

        public void Update(string questStatus)
        {
            Console.WriteLine($"{Name} received quest update: {questStatus}");
        }
    }
}