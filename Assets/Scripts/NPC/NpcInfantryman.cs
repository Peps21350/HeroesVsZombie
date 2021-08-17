using System;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class NpcInfantryman : Npc
    {
        
        public override  IWeapon weapon => new WeaponSpear("spear", 10, 1.3f, 5f);
        public override void Display_information()
        {
            throw new System.NotImplementedException();
            // $" Name: {Name}
            // Health: {Health}
            // Price to unlock: {Price}
            // Damage: 
        }
        
        

        //public IWeapon spear_for_infantryman = new WeaponSpear("spear", 10, 1.3f, 5f);

        // private IWeapon m4 = new PoisonousBile("M4", 6,  4,  6);
    }
}