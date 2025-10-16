namespace Items
{
    public class Armor : Item
    {
        public int Defense { get; set; }
        public int Durability { get; set; }

        public Armor(string name, Enums.ItemRarity rarity, int defense, int durability)
            : base(name, rarity)
        {
            Defense = defense;
            Durability = durability;
        }

        public override string ToString()
        {
            return $"{Rarity} Armor: {Name}, Defense: {Defense}, Durability: {Durability}";
        }
    }
}
