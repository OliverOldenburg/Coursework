namespace Factories
{
    public class LegendaryItemFactory : ItemFactory
    {
        public Items.Weapon CreateWeapon()
        {
            return new Items.Weapon("Legendary Sword of Light", Enums.ItemRarity.Legendary, 100, Enums.WeaponTypeEnum.Melee);
        }

        public Items.Potion CreatePotion()
        {
            return new Items.Potion("Legendary Potion of Immortality", Enums.ItemRarity.Legendary, "Invincibility for 60 seconds", 60);
        }

        public Items.Armor CreateArmor()
        {
            return new Items.Armor("Legendary Dragon Armor", Enums.ItemRarity.Legendary, 50, 200);
        }
    }
}
