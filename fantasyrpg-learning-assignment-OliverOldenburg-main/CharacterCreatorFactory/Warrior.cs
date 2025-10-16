namespace CharacterFactoryPattern
{
    public class Warrior : Character
    {
        public Warrior(string name) : base(name, 150, 50, 100, 50) { }

        public override void DisplayStats()
        {
            Console.WriteLine($"Warrior {Name}: Health = {Health}, Mana = {Mana}, Strength = {Strength}, Agility = {Agility}");
        }
    }
}
