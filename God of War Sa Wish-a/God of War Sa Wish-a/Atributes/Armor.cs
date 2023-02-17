using System;

namespace God_of_War_Sa_Wish_a
{
    public class Armor
    {
        public Armor(int armorId, string armorName, int health, int shield, int defense)
        {
            ArmorId = armorId;
            ArmorName = armorName;
            Health = health;
            Shield = shield;
            Defense = defense;
        }

        public Armor()
        {
        }

        public int ArmorId { get; set; }
        public String ArmorName { get; set; }
        public int Health { get; set; }
        public int Shield { get; set; } 
        public int Defense { get; set; } 
        
        public override string ToString()
        {
            return "Armor Id: " + Convert.ToString(ArmorId) + "\nArmor Name: " + ArmorName
                   + "\nHealth: " + Convert.ToString(Health)
                   + "\nShield : " + Convert.ToString(Shield)
                   + "\nDefense : " + Convert.ToString(Defense);
        }
    }
}