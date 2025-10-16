using System;
using System.Collections.Generic;
using Items;

namespace InventoryManagement
{
    // Base Item Class
    public abstract class Item
    {
        public string Name { get; set; }
        public string ItemType { get; set; }

        protected Item(string name, string itemType)
        {
            Name = name;
            ItemType = itemType;
        }

        public override string ToString()
        {
            return $"{ItemType}: {Name}";
        }
    }

    // Derived Item Classes
    public class Weapon : Item
    {
        public int Damage { get; set; }

        public Weapon(string name, int damage) : base(name, "Weapon")
        {
            Damage = damage;
        }

        public override string ToString()
        {
            return base.ToString() + $" (Damage: {Damage})";
        }
    }

    public class DefensiveItem : Item
    {
        public int Defense { get; set; }

        public DefensiveItem(string name, int defense) : base(name, "Defensive Item")
        {
            Defense = defense;
        }

        public override string ToString()
        {
            return base.ToString() + $" (Defense: {Defense})";
        }
    }

    public class UtilityItem : Item
    {
        public string Effect { get; set; }

        public UtilityItem(string name, string effect) : base(name, "Utility Item")
        {
            Effect = effect;
        }

        public override string ToString()
        {
            return base.ToString() + $" (Effect: {Effect})";
        }
    }

    // Inventory Class
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
            Console.WriteLine($"{item.Name} added to inventory.");
        }

        public void RemoveItem(string itemName)
        {
            Item itemToRemove = _items.Find(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (itemToRemove != null)
            {
                _items.Remove(itemToRemove);
                Console.WriteLine($"{itemName} removed from inventory.");
            }
            else
            {
                Console.WriteLine($"{itemName} not found in inventory.");
            }
        }

        public Item FindItem(string itemName)
        {
            return _items.Find(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        }

        public void ListItems()
        {
            Console.WriteLine("\nCurrent Inventory:");
            if (_items.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
            }
            else
            {
                foreach (var item in _items)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
