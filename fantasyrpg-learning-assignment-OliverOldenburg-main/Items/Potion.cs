namespace Items
{
    public class Potion : Item
    {
        public string Effect { get; set; }
        public int Duration { get; set; }

        public Potion(string name, Enums.ItemRarity rarity, string effect, int duration)
            : base(name, rarity)
        {
            Effect = effect;
            Duration = duration;
        }

        public override string ToString()
        {
            return $"{Rarity} Potion: {Name}, Effect: {Effect}, Duration: {Duration} seconds";
        }
    }
}
