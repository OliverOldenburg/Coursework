using Strategies;
using States;
using System;
using InventoryManagement;

namespace CharacterFactoryPattern
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }

        public Inventory Inventory { get; private set; }

        // Equipment slots
        public Item WeaponSlot { get; private set; }
        public Item DefensiveSlot { get; private set; }
        public Item UtilitySlot { get; private set; }

        public Character(string name, int health, int mana, int strength, int agility)
        {
            Name = name;
            Health = health;
            Mana = mana;
            Strength = strength;
            Agility = agility;
            Inventory = new Inventory();
        }

        public abstract void DisplayStats();

        // State additions:
        private CharacterState _currentState;
        private ActionStrategy _actionStrategy;

        public Character(string name)
        {
            Name = name;
            _currentState = new IdleState(); // Default to Idle State
            Inventory = new Inventory(); // Initialize Inventory
        }

        public void SetActionStrategy(ActionStrategy actionStrategy)
        {
            _actionStrategy = actionStrategy;
            Console.WriteLine($"{Name} switches action strategy.");
        }

        public void SetState(CharacterState newState)
        {
            _currentState = newState;
            Console.WriteLine($"{Name} changes state.");
        }

        public void PerformAction()
        {
            if (_currentState is ActionState)
            {
                ((ActionState)_currentState).SetActionStrategy(_actionStrategy);
            }
            _currentState.HandleState();
        }

        public void EquipItem(string itemName)
        {
            Item itemToEquip = Inventory.FindItem(itemName);
            if (itemToEquip == null)
            {
                Console.WriteLine($"Item '{itemName}' not found in inventory.");
                return;
            }

            switch (itemToEquip.ItemType)
            {
                case "Weapon":
                    if (WeaponSlot != null)
                    {
                        Console.WriteLine($"Unequipping {WeaponSlot.Name} from Weapon Slot.");
                        Inventory.AddItem(WeaponSlot);
                    }
                    WeaponSlot = itemToEquip;
                    break;

                case "Defensive Item":
                    if (DefensiveSlot != null)
                    {
                        Console.WriteLine($"Unequipping {DefensiveSlot.Name} from Defensive Slot.");
                        Inventory.AddItem(DefensiveSlot);
                    }
                    DefensiveSlot = itemToEquip;
                    break;

                case "Utility Item":
                    if (UtilitySlot != null)
                    {
                        Console.WriteLine($"Unequipping {UtilitySlot.Name} from Utility Slot.");
                        Inventory.AddItem(UtilitySlot);
                    }
                    UtilitySlot = itemToEquip;
                    break;

                default:
                    Console.WriteLine("Invalid item type for equipment slots.");
                    return;
            }

            Inventory.RemoveItem(itemName);
            Console.WriteLine($"Equipped {itemToEquip.Name} in the {itemToEquip.ItemType} Slot.");
        }

        public void UnequipItem(string slotType)
        {
            switch (slotType.ToLower())
            {
                case "weapon":
                    if (WeaponSlot != null)
                    {
                        Console.WriteLine($"Unequipping {WeaponSlot.Name} from Weapon Slot.");
                        Inventory.AddItem(WeaponSlot);
                        WeaponSlot = null;
                    }
                    else
                    {
                        Console.WriteLine("Weapon Slot is already empty.");
                    }
                    break;

                case "defensive":
                    if (DefensiveSlot != null)
                    {
                        Console.WriteLine($"Unequipping {DefensiveSlot.Name} from Defensive Slot.");
                        Inventory.AddItem(DefensiveSlot);
                        DefensiveSlot = null;
                    }
                    else
                    {
                        Console.WriteLine("Defensive Slot is already empty.");
                    }
                    break;

                case "utility":
                    if (UtilitySlot != null)
                    {
                        Console.WriteLine($"Unequipping {UtilitySlot.Name} from Utility Slot.");
                        Inventory.AddItem(UtilitySlot);
                        UtilitySlot = null;
                    }
                    else
                    {
                        Console.WriteLine("Utility Slot is already empty.");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid slot type.");
                    break;
            }
        }

        public void ViewEquippedItems()
        {
            Console.WriteLine("\nEquipped Items:");
            Console.WriteLine($"Weapon Slot: {(WeaponSlot != null ? WeaponSlot.Name : "Empty")}");
            Console.WriteLine($"Defensive Slot: {(DefensiveSlot != null ? DefensiveSlot.Name : "Empty")}");
            Console.WriteLine($"Utility Slot: {(UtilitySlot != null ? UtilitySlot.Name : "Empty")}");
        }

        public void ManageInventory()
        {
            bool managing = true;
            while (managing)
            {
                Console.WriteLine("\nInventory Management:");
                Console.WriteLine("1: Add Item");
                Console.WriteLine("2: Remove Item");
                Console.WriteLine("3: View Inventory");
                Console.WriteLine("4: Exit Inventory Management");
                Console.Write("Your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter item type (Weapon, Defensive, Utility): ");
                        string type = Console.ReadLine();
                        Console.Write("Enter item name: ");
                        string name = Console.ReadLine();

                        if (type.Equals("Weapon", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.Write("Enter damage: ");
                            int damage = int.Parse(Console.ReadLine());
                            Inventory.AddItem(new Weapon(name, damage));
                        }
                        else if (type.Equals("Defensive", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.Write("Enter defense: ");
                            int defense = int.Parse(Console.ReadLine());
                            Inventory.AddItem(new DefensiveItem(name, defense));
                        }
                        else if (type.Equals("Utility", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.Write("Enter effect: ");
                            string effect = Console.ReadLine();
                            Inventory.AddItem(new UtilityItem(name, effect));
                        }
                        else
                        {
                            Console.WriteLine("Invalid item type.");
                        }
                        break;

                    case 2:
                        Console.Write("Enter the name of the item to remove: ");
                        string itemName = Console.ReadLine();
                        Inventory.RemoveItem(itemName);
                        break;

                    case 3:
                        Inventory.ListItems();
                        break;

                    case 4:
                        managing = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
