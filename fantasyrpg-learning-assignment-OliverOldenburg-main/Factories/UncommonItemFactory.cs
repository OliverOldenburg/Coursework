namespace Factories
{
    public class UncommonItemFactory : ItemFactory
    {
        public Items.Weapon CreateWeapon()
        {
            return new Items.Weapon("Uncommon Staff", Enums.ItemRarity.Uncommon, 25, Enums.WeaponTypeEnum.Ranged);
        }

        public Items.Potion CreatePotion()
        {
            return new Items.Potion("Uncommon Mana Potion", Enums.ItemRarity.Uncommon, "Restore 50 Mana", 10);
        }

        public Items.Armor CreateArmor()
        {
            return new Items.Armor("Uncommon Robes", Enums.ItemRarity.Uncommon, 10, 60);
        }
    }
}
