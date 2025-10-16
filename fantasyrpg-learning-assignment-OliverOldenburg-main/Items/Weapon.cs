namespace Items
{
    public class Weapon : Item
    {
        public int Damage { get; set; }
        public Enums.WeaponTypeEnum WeaponType { get; set; }

        public Weapon(string name, Enums.ItemRarity rarity, int damage, Enums.WeaponTypeEnum weaponType)
            : base(name, rarity)
        {
            Damage = damage;
            WeaponType = weaponType;
        }

        public override string ToString()
        {
            return $"{Rarity} Weapon: {Name}, Damage: {Damage}, Type: {WeaponType}";
        }
    }
}
