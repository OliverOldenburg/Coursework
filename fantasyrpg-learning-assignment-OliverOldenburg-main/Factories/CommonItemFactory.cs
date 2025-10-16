namespace Factories
{
    public class CommonItemFactory : ItemFactory
    {
        public Items.Weapon CreateWeapon()
        {
            return new Items.Weapon("Common Sword", Enums.ItemRarity.Common, 10, Enums.WeaponTypeEnum.Melee);
        }

        public Items.Potion CreatePotion()
        {
            return new Items.Potion("Common Health Potion", Enums.ItemRarity.Common, "Heal 20 HP", 5);
        }

        public Items.Armor CreateArmor()
        {
            return new Items.Armor("Common Leather Armor", Enums.ItemRarity.Common, 5, 50);
        }
    }
}
