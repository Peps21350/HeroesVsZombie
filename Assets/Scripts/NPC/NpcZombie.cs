using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class NpcZombie : Npc
    {

       // public override IWeapon weapon => new WeaponPoisonousBile("poisonous bile", 12f, 1.5f, 2f);
        
        public override void Display_information()
        {
            throw new System.NotImplementedException();
            // $" Name: {Name}
            // Health: {Health}
            // Price to unlock: {Price}
            // Damage: 
        }
    }
}
