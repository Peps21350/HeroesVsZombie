using UnityEngine;

namespace DefaultNamespace
{
    public class NpcRobot : Npc
    {

        
        //public override IWeapon weapon => new WeaponM4("M4",  10,  4,  6);
        
        public override void Display_information()
        {
            // $" Name: {Name}
            // Health: {Health}
            // Price to unlock: {Price}
            // Damage: 
        }
        
        //private IWeapon m4 = new PoisonousBile("M4",  6,  4,  6);
    }
}