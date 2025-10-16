namespace Items
{
    public abstract class Item
    {
        public string Name { get; set; }
        public Enums.ItemRarity Rarity { get; set; }

        protected Item(string name, Enums.ItemRarity rarity)
        {
            Name = name;
            Rarity = rarity;
        }
    }
}
