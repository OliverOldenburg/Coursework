namespace CharacterFactoryPattern
{
    public class CharacterFactory
    {
        public static Character CreateCharacter(string? type, string name)
        {
            if (string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Character type and name must not be empty.");
            }

            switch (type.ToLower())
            {
                case "warrior":
                    return new Warrior(name);
                case "mage":
                    return new Mage(name);
                case "archer":
                    return new Archer(name);
                default:
                    throw new ArgumentException("Invalid character type. Choose Warrior, Mage, or Archer.");
            }
        }
    }
}
