using GameWorldSingleton;
public class Location
{
    public string Name { get; set; }
    public string Type { get; set; } // Village, Town, Dungeon
    public List<NPC> NPCs { get; private set; }

    public Location(string name, string type)
    {
        Name = name;
        Type = type;
        NPCs = new List<NPC>();
    }

    public void AddNPC(NPC npc)
    {
        NPCs.Add(npc);
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Location: {Name} ({Type})");
        Console.WriteLine("NPCs in this location:");
        foreach (var npc in NPCs)
        {
            Console.WriteLine($"- {npc.Name} ({npc.Role})");
        }
    }
}
