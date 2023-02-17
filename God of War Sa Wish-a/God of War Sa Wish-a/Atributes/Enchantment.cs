using System;

namespace CS322_DZ13
{
    public class Enchantment
    {
        public Enchantment(int enchantmentId, string enchantmentName, int damage, int defense, int luck)
        {
            EnchantmentId = enchantmentId;
            EnchantmentName = enchantmentName;
            Damage = damage;
            Defense = defense;
            Luck = luck;
        }

        public Enchantment()
        {
        }

        public int EnchantmentId { get; set; }
        public String EnchantmentName { get; set; }
        public int Damage { get; set; }
        public int Defense { get; set; }
        public int Luck { get; set; }
        
        public override string ToString()
        {
            return "Skill Id: " + Convert.ToString(EnchantmentId) + "\nSkill Name: " + EnchantmentName
                   + "\nDamage: " + Convert.ToString(Damage)
                   + "\nDefense: " + Convert.ToString(Defense)
                   + "\nLuck: " + Convert.ToString(Luck);
        }
    }
}