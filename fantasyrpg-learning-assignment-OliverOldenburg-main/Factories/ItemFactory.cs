namespace Factories
{
    public interface ItemFactory
    {
        Items.Weapon CreateWeapon();
        Items.Potion CreatePotion();
        Items.Armor CreateArmor();
    }
}
