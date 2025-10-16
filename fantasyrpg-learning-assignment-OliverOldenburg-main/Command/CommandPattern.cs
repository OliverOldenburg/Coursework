using CharacterFactoryPattern;
using States;
using BaseClasses;
using GameWorldSingleton;
using InventoryManagement;
using System.Collections.Generic;

namespace CommandPattern
{
    // Command Interface
    public interface ICommand
    {
        void Execute();
    }

    // Concrete Commands
    public class AttackCommand : ICommand
    {
        private Character _character;
        private Enemy _enemy;

        public AttackCommand(Character character, Enemy enemy)
        {
            _character = character;
            _enemy = enemy;
        }

        public void Execute()
        {
            Console.WriteLine($"{_character.Name} attacks {_enemy.Name}!");
            _enemy.Health -= _character.Strength;
            Console.WriteLine($"{_enemy.Name} now has {_enemy.Health} health.");
        }
    }

    public class DefendCommand : ICommand
    {
        private Character _character;

        public DefendCommand(Character character)
        {
            _character = character;
        }

        public void Execute()
        {
            Console.WriteLine($"{_character.Name} is defending!");
            _character.SetState(new DefendingState());
        }
    }

    public class HealCommand : ICommand
    {
        private Character _character;

        public HealCommand(Character character)
        {
            _character = character;
        }

        public void Execute()
        {
            Console.WriteLine($"{_character.Name} heals!");
            _character.Health += 20; // Arbitrary healing value
            Console.WriteLine($"{_character.Name} now has {_character.Health} health.");
        }
    }

    public class MoveCommand : ICommand
    {
        private Character _character;
        private string _destination;

        public MoveCommand(Character character, string destination)
        {
            _character = character;
            _destination = destination;
        }

        public void Execute()
        {
            Console.WriteLine($"{_character.Name} moves to {_destination}.");
        }
    }

    public class LocationCommand : ICommand
    {
        private GameWorld _gameWorld;
        private Character _character;

        public LocationCommand(GameWorld gameWorld, Character character)
        {
            _gameWorld = gameWorld;
            _character = character;
        }

        public void Execute()
        {
            Console.WriteLine("\nAvailable Locations:");
            _gameWorld.DisplayLocations();

            Console.Write("Enter the name of the location to move to: ");
            string locationName = Console.ReadLine();

            Location selectedLocation = _gameWorld.FindLocation(locationName);
            if (selectedLocation != null)
            {
                Console.WriteLine($"Moving {_character.Name} to {selectedLocation.Name}.");
                selectedLocation.DisplayDetails();

                Console.WriteLine("\nInteract with an NPC. Enter the name of the NPC:");
                string npcName = Console.ReadLine();
                NPC npc = selectedLocation.NPCs.Find(n => n.Name.Equals(npcName, StringComparison.OrdinalIgnoreCase));

                if (npc != null)
                {
                    if (npc.Name.Equals("Gorin", StringComparison.OrdinalIgnoreCase))
                    {
                        InteractWithGorin(npc);
                    }
                    else
                    {
                        Console.WriteLine($"Interacting with {npc.Name} ({npc.Role}).");
                        npc.DisplayQuests();

                        Console.WriteLine("\nWould you like to accept a quest? (yes/no):");
                        string questResponse = Console.ReadLine().ToLower();
                        if (questResponse == "yes")
                        {
                            Console.WriteLine("Enter the description of the quest to accept:");
                            string questDescription = Console.ReadLine();
                            Quest quest = npc.Quests.Find(q => q.Description.Equals(questDescription, StringComparison.OrdinalIgnoreCase));

                            if (quest != null)
                            {
                                Console.WriteLine($"Quest accepted: {quest.Description}.");
                                quest.CompleteQuest();
                            }
                            else
                            {
                                Console.WriteLine("No matching quest found.");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("NPC not found.");
                }
            }
            else
            {
                Console.WriteLine("Location not found.");
            }
        }

        private void InteractWithGorin(NPC npc)
        {
            Quest trollQuest = npc.Quests.Find(q => q.Description.Contains("Defeat the cave troll"));

            if (trollQuest != null && trollQuest.IsCompleted)
            {
                Console.WriteLine("\nGorin: You’ve done it! The Cave Troll is defeated. Thank you so much, adventurer!");
                Console.WriteLine("You’ve already completed this quest.");
                return;
            }

            Console.WriteLine("\nGorin: Hello there! I am in need of an adventurer to help our village, could you be the one?");
            Console.Write("(yes/no): ");
            string firstResponse = Console.ReadLine().ToLower();

            if (firstResponse == "yes")
            {
                Console.WriteLine("\nGorin: Oh thank you! Our village is under attack by a Cave Troll, could you get rid of him? I have a nice sword I could give you in exchange!");
                Console.Write("(yes/no): ");
                string secondResponse = Console.ReadLine().ToLower();

                if (secondResponse == "yes")
                {
                    Console.WriteLine("\nGorin: Thank you, adventurer! Please help us defeat the Cave Troll!");
                    
                    if (trollQuest != null)
                    {
                        Console.WriteLine($"Quest accepted: {trollQuest.Description}.");
                        trollQuest.CompleteQuest();
                        _character.Inventory.AddItem(new Weapon("Rare Sword", 100));
                        Console.WriteLine("You received a Rare Sword!");
                    }
                    else
                    {
                        Console.WriteLine("There seems to be an error; no quest is assigned to Gorin.");
                    }
                }
                else
                {
                    Console.WriteLine("\nGorin: Oh, that's too bad, hopefully the next adventurer can aid us!");
                }
            }
            else
            {
                Console.WriteLine("\nGorin: Oh, that's too bad, hopefully the next adventurer can aid us!");
            }
        }
    }

    public class InventoryCommand : ICommand
    {
        private Character _character;

        public InventoryCommand(Character character)
        {
            _character = character;
        }

        public void Execute()
        {
            _character.ManageInventory();
        }
    }

    public class EquipmentCommand : ICommand
    {
        private Character _character;

        public EquipmentCommand(Character character)
        {
            _character = character;
        }

        public void Execute()
        {
            bool managingEquipment = true;
            while (managingEquipment)
            {
                Console.WriteLine("\nEquipment Management:");
                Console.WriteLine("1: Equip Item");
                Console.WriteLine("2: Unequip Item");
                Console.WriteLine("3: View Equipped Items");
                Console.WriteLine("4: Exit Equipment Management");
                Console.Write("Your choice: ");
                int equipChoice = int.Parse(Console.ReadLine());

                switch (equipChoice)
                {
                    case 1:
                        Console.Write("Enter the name of the item to equip: ");
                        string equipItemName = Console.ReadLine();
                        _character.EquipItem(equipItemName);
                        break;

                    case 2:
                        Console.Write("Enter the slot to unequip (Weapon, Defensive, Utility): ");
                        string slotType = Console.ReadLine();
                        _character.UnequipItem(slotType);
                        break;

                    case 3:
                        _character.ViewEquippedItems();
                        break;

                    case 4:
                        managingEquipment = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }

    // Invoker
    public class GameController
    {
        private List<ICommand> _commandHistory = new List<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _commandHistory.Add(command);
        }
    }
}
