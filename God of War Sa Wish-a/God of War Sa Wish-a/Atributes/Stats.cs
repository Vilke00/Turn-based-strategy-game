using System;

namespace God_of_War_Sa_Wish_a
{
    public class Stats
    {
            public Stats(int statId, string characterName, int enchantmentId, int armorId, int abilityId)
            {
                StatId = statId;
                CharacterName = characterName;
                EnchantmentId = enchantmentId;
                ArmorId = armorId;
                AbilityId = abilityId;
            }

            public Stats()
            {
            }
            public int StatId { get; set; }

            public String CharacterName { get; set; }
            public int EnchantmentId { get; set; }
            public int ArmorId { get; set; }
            public int AbilityId { get; set; }

            public override string ToString()
            {
                return "Stat Id: " + Convert.ToString(StatId) 
                       + "\nCharacter Name: " + CharacterName 
                       + "\nEnchantment Id: " + Convert.ToString(EnchantmentId)
                       + "\nArmor Id: " + Convert.ToString(ArmorId)
                       + "\nAbility Id: " + Convert.ToString(AbilityId);
            }
    }
}