namespace CharacterFactoryPattern
{
    public class Mage : Character
    {
        public Mage(string name) : base(name, 75, 200, 50, 50) { }

        public override void DisplayStats()
        {
            Console.WriteLine($"Mage {Name}: Health = {Health}, Mana = {Mana}, Strength = {Strength}, Agility = {Agility}");
        }
    }
}
