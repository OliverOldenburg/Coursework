using GameWorldSingleton;
using CharacterFactoryPattern;
using Factories;
using Enums;
using Items;
using States;
using Strategies;
using BaseClasses;
using QuestNotificationSystem;
using CommandPattern;
using ControllerFeature;
using InventoryManagement;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine("!!IN THIS BUILD, ONLY GORIN IN RIVERTOWN HAS INTERACTABILITY!!");
        Console.WriteLine("--------------------------------------------------------------");
        // Initialize Game World
        GameWorld gameWorld = GameWorld.GetInstance();

        // Add Locations to GameWorld
        Location village = new Location("Eldoria", "Village");
        Location town = new Location("Rivertown", "Town");
        Location dungeon = new Location("Shadow Cavern", "Dungeon");
        

        gameWorld.AddLocation(village);
        gameWorld.AddLocation(town);
        gameWorld.AddLocation(dungeon);

        // Add NPCs to Locations
        NPC villager = new NPC("Lara", "Villager");
        NPC merchant = new NPC("Gorin", "Merchant");
        NPC king = new NPC("Theron", "King");

        Quest herbQuest = new Quest("Gather 10 herbs", "50 gold");
        villager.AssignQuest(herbQuest);

        Quest trollQuest = new Quest("Defeat the cave troll", "Rare sword");
        merchant.AssignQuest(trollQuest);

        village.AddNPC(villager);
        town.AddNPC(merchant);
        dungeon.AddNPC(king);

        // Display initial world state
        Console.WriteLine("Initial Game World State:");
        gameWorld.DisplayWorldState();
        Console.WriteLine("");

        // Ask user for character class and name
        Console.WriteLine("Choose your character class (Warrior, Mage, Archer):");
        string? characterClass = Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine("Enter your character's name:");
        string? characterName = Console.ReadLine();
        Console.WriteLine("");

        CharacterFactoryPattern.Character character;

        try
        {
            // Create character using the factory based on user input
            character = CharacterFactory.CreateCharacter(characterClass, characterName);
            character.DisplayStats();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return; // Exit program if there's an error in character creation
        }

        // Check if character was created
        if (character == null)
        {
            Console.WriteLine("Character creation failed. Exiting program.");
            return;
        }

        // Create item factories
        ItemFactory commonFactory = new CommonItemFactory();
        ItemFactory uncommonFactory = new UncommonItemFactory();
        ItemFactory rareFactory = new RareItemFactory();

        // Hardcoded items
        Items.Weapon commonWeapon = commonFactory.CreateWeapon(); // Common Melee Weapon
        Potion uncommonPotion = uncommonFactory.CreatePotion(); // Uncommon Potion
        Armor rareArmor = rareFactory.CreateArmor(); // Rare Armor

        // Get user input to create a new item to test functionality
        Console.WriteLine("\nNow, create a new item of your choosing!");

        Console.Write("Enter the rarity of the item (Common, Uncommon, Rare, Legendary): ");
        string rarityInput = Console.ReadLine();
        ItemRarity rarity = (ItemRarity)Enum.Parse(typeof(ItemRarity), rarityInput, true);
        Console.WriteLine("");

        Console.Write("Enter the type of the item (Weapon, Potion, Armor): ");
        string itemType = Console.ReadLine();
        

        ItemFactory selectedFactory;

        // Determine which factory to use based on rarity input
        switch (rarity)
        {
            case ItemRarity.Common:
                selectedFactory = new CommonItemFactory();
                break;
            case ItemRarity.Uncommon:
                selectedFactory = new UncommonItemFactory();
                break;
            case ItemRarity.Rare:
                selectedFactory = new RareItemFactory();
                break;
            case ItemRarity.Legendary:
                selectedFactory = new LegendaryItemFactory();
                break;
            default:
                Console.WriteLine("Invalid rarity input.");
                return;
        }

        Items.Item newItem = null;

        // Create item based on user input
        switch (itemType.ToLower())
        {
            case "weapon":
                newItem = selectedFactory.CreateWeapon();
                break;
            case "potion":
                newItem = selectedFactory.CreatePotion();
                break;
            case "armor":
                newItem = selectedFactory.CreateArmor();
                break;
            default:
                Console.WriteLine("Invalid item type.");
                return;
        }

        // Display all created items (hardcoded + user-created)
        Console.WriteLine("\nAll Created Items:");
        Console.WriteLine(commonWeapon);
        Console.WriteLine(uncommonPotion);
        Console.WriteLine(rareArmor);
        Console.WriteLine("");
        if (newItem != null)
        {
            Console.WriteLine(newItem);
        }
        else
        {
            Console.WriteLine("No valid item was created from user input.");
        }

        // Create factories for enemies
        EnemyFactory slimeFactory = new SlimeFactory();
        EnemyFactory goblinFactory = new GoblinFactory();
        EnemyFactory dragonFactory = new DragonFactory();

        // Create enemies with different ranks
        Enemy normalSlime = slimeFactory.CreateEnemy(EnemyRank.Normal);
        Enemy eliteGoblin = goblinFactory.CreateEnemy(EnemyRank.Elite);
        Enemy kingDragon = dragonFactory.CreateEnemy(EnemyRank.King);

        // Display enemies
        Console.WriteLine(normalSlime);
        Console.WriteLine(eliteGoblin);
        Console.WriteLine(kingDragon);
        Console.WriteLine("");
        // Initialize Quest Notification System
        QuestManager questManager = new QuestManager();

        // Subscribe player character to the quest manager
        PlayerCharacter playerObserver = new PlayerCharacter(character.Name);
        questManager.Subscribe(playerObserver);

        // Example NPC subscription
        NPCs npcObserver = new NPCs("Town Elder");
        questManager.Subscribe(npcObserver);

        // Change quest status and notify observers
        questManager.ChangeQuestStatus("Quest Started: Retrieve the Sacred Artifact");
        Console.WriteLine();

        // Unsubscribe the NPC
        questManager.Unsubscribe(npcObserver);

        // Change quest status again
        questManager.ChangeQuestStatus("Quest Completed: Sacred Artifact Retrieved");
        Console.WriteLine();

        // Initialize Controller and map commands
        Controller controller = new Controller();
        controller.MapKeyToCommand(ConsoleKey.A, new AttackCommand(character, normalSlime));
        controller.MapKeyToCommand(ConsoleKey.D, new DefendCommand(character));
        controller.MapKeyToCommand(ConsoleKey.H, new HealCommand(character));
        controller.MapKeyToCommand(ConsoleKey.M, new MoveCommand(character, "Castle"));
        controller.MapKeyToCommand(ConsoleKey.I, new InventoryCommand(character));
        controller.MapKeyToCommand(ConsoleKey.E, new EquipmentCommand(character));


        // Add Movement in Controller
        controller.MapKeyToCommand(ConsoleKey.L, new LocationCommand(gameWorld, character));

        Console.WriteLine("\nUse the controller to perform actions and explore locations:");
        Console.WriteLine("A: Attack, D: Defend, H: Heal, M: Move, L: Explore Locations, I: Open Inventory, E: Open EquipmentQ: Quit Controller\n");
        controller.Listen();

        Console.WriteLine($"Exiting the program. Thank you, {characterName}!");
    }
}
