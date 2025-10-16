public class Quest
{
    public string Description { get; set; }
    public string Reward { get; set; } // Gold, items, etc.
    public bool IsCompleted { get; private set; }

    public Quest(string description, string reward)
    {
        Description = description;
        Reward = reward;
        IsCompleted = false;
    }

    public void CompleteQuest()
    {
        IsCompleted = true;
        Console.WriteLine($"Quest completed: {Description}. Reward: {Reward}.");
    }
}
