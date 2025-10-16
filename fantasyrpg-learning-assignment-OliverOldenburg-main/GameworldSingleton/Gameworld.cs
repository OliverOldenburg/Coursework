namespace GameWorldSingleton
{
    public class GameWorld
    {
    private static GameWorld? _instance;
    public List<Location> Locations { get; private set; }
    public string TimeOfDay { get; set; }
    public string WeatherCondition { get; set; }

    private GameWorld()
    {
        Locations = new List<Location>();
        TimeOfDay = "Day";
        WeatherCondition = "Clear";
    }

    public static GameWorld GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameWorld();
        }
        return _instance;
    }

    public void AddLocation(Location location)
    {
        Locations.Add(location);
    }

    public void DisplayLocations()
    {
        Console.WriteLine("GameWorld Locations:");
        foreach (var location in Locations)
        {
            location.DisplayDetails();
        }
    }

    public Location FindLocation(string name)
    {
        return Locations.Find(loc => loc.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
    
    public void DisplayWorldState()
    {
    Console.WriteLine($"Time of Day: {TimeOfDay}, Weather: {WeatherCondition}");
    Console.WriteLine("Available Locations:");
    foreach (var location in Locations)
    {
        Console.WriteLine($"- {location.Name} ({location.Type})");
    }
    }
    }
}

