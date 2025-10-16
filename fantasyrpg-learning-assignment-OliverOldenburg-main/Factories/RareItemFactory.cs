namespace Factories
{
    public class RareItemFactory : ItemFactory
    {
        public Items.Weapon CreateWeapon()
        {
            return new Items.Weapon("Rare Battle Axe", Enums.ItemRarity.Rare, 40, Enums.WeaponTypeEnum.Melee);
        }

        public Items.Potion CreatePotion()
        {
            return new Items.Potion("Rare Elixir", Enums.ItemRarity.Rare, "Heal 100 HP and Restore 50 Mana", 15);
        }

        public Items.Armor CreateArmor()
        {
            return new Items.Armor("Rare Chainmail", Enums.ItemRarity.Rare, 20, 80);
        }
    }
}
