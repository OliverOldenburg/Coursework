using Enums;

namespace BaseClasses
{
    public abstract class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public EnemyRank Rank { get; set; }

        public Enemy(string name, EnemyRank rank)
        {
            Name = name;
            Rank = rank;
            AdjustStatsBasedOnRank();
        }

        private void AdjustStatsBasedOnRank()
        {
            switch (Rank)
            {
                case EnemyRank.Elite:
                    Health += 50;
                    Mana += 30;
                    Strength += 10;
                    Agility += 5;
                    break;
                case EnemyRank.King:
                    Health += 100;
                    Mana += 50;
                    Strength += 20;
                    Agility += 10;
                    break;
            }
        }

        public abstract void Move();
        public abstract void Attack();

        public override string ToString()
        {
            return $"Name: {Name}, Rank: {Rank}, Health: {Health}, Mana: {Mana}, Strength: {Strength}, Agility: {Agility}";
        }
    }
}