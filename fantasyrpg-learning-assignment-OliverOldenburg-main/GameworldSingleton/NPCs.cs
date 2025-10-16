public class NPC
{
    public string Name { get; set; }
    public string Role { get; set; } // Villager, Merchant, King/Queen
    public List<Quest> Quests { get; private set; }

    public NPC(string name, string role)
    {
        Name = name;
        Role = role;
        Quests = new List<Quest>();
    }

    public void AssignQuest(Quest quest)
    {
        Quests.Add(quest);
    }

    public void DisplayQuests()
    {
        if (Quests.Count == 0)
        {
            Console.WriteLine($"{Name} has no quests available.");
            return;
        }

        Console.WriteLine($"Quests available from {Name}:");
        foreach (var quest in Quests)
        {
            Console.WriteLine($"- {quest.Description} (Reward: {quest.Reward})");
        }
    }
}
