namespace QuestNotificationSystem
{
    public class NPCs : Observer
    {
        public string Name { get; private set; }

        public NPCs(string name)
        {
            Name = name;
        }

        public void Update(string questStatus)
        {
            Console.WriteLine($"NPC {Name} has been notified of quest update: {questStatus}");
        }
    }
}