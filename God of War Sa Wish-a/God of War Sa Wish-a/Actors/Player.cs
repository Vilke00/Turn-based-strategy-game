using System;

namespace God_of_War_Sa_Wish_a
{
    public class Player
    {
        public Player(string characterName, int health, int shield, int damage, int defense, int luck, int energy)
        {
            CharacterName = characterName;
            Health = health;
            Shield = shield;
            Damage = damage;
            Defense = defense;
            Luck = luck;
            Energy = energy;
        }

        public Player()
        {
        }

        public String CharacterName { get; set; }
        public int Health { get; set; }
        public int Shield { get; set; }
        public int Damage { get; set; }
        public int Defense { get; set; }
        public int Luck { get; set; }
        public int Energy { get; set; }

        public override string ToString()
        {
            return "Character Name: " + CharacterName + "\nHealth: " + Convert.ToString(Health)
                   + "\nShield: " + Convert.ToString(Shield)
                   + "\nDamage: " + Convert.ToString(Damage)
                   + "\nDefense: " + Convert.ToString(Defense)
                   + "\nLuck: " + Convert.ToString(Luck)
                   + "\nEnergy: " + Convert.ToString(Energy);
        }
    }
}