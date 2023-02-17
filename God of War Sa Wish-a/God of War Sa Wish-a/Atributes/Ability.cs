using System;

namespace CS322_DZ13
{
    public class Ability
    {
        public Ability(int abilityId, string abilityName, int damage, int energyReq)
        {
            AbilityId = abilityId;
            AbilityName = abilityName;
            Damage = damage;
            EnergyReq = energyReq;
        }

        public Ability()
        {
        }

        public int AbilityId { get; set; }
        public String AbilityName { get; set; }
        public int Damage { get; set; }
        public int EnergyReq { get; set; }
        
        public override string ToString()
        {
            return "Skill Id: " + Convert.ToString(AbilityId) + "\nSkill Name: " + AbilityName
                   + "\nDamage " + Convert.ToString(Damage)
                   + "\nEnergyReq " + Convert.ToString(EnergyReq);
        }
    }
}