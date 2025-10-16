namespace CharacterFactoryPattern
{
    public class Archer : Character
    {
        public Archer(string name) : base(name, 100, 75, 75, 125) { }

        public override void DisplayStats()
        {
            Console.WriteLine($"Archer {Name}: Health = {Health}, Mana = {Mana}, Strength = {Strength}, Agility = {Agility}");
        }
    }
}
