using UnityEngine;

namespace DefaultNamespace
{
    public class NpcRobot : Npc
    {
        public void init(string name, float health, float current_health,float speed_of_movement, int price_to_spawn, int price)
        {
            this.name = name;
            this.health = health;
            this.current_health = current_health;
            this.speed_of_movement = speed_of_movement;
            this.price_to_spawn = price_to_spawn;
            price_to_unlock = price;
        }

        public override void Give_damage()
        {
            throw new System.NotImplementedException();
        }

        public override void Take_damage()
        {
            throw new System.NotImplementedException();
        }
        
        public  IWeapon weapon { get; set; }
        
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