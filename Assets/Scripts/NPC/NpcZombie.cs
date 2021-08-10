using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class NpcZombie : Npc
    {
        public Slider slider_hp;
        // public NpcZombie(string name, float health,float currentHealth,float speedOfMovement, int priceToSpawn)
        // {
        //     this.name = name;
        //     this.health = health;
        //     this.currentHealth = currentHealth;
        //     this.speedOfMovement = speedOfMovement;
        //     this.priceToSpawn = priceToSpawn;
        // }

        protected NpcZombie()
        {

        }

        public override void Give_damage()
        {
            throw new System.NotImplementedException();
        }
        
        public override void init(string name, float health, float current_health,float speed_of_movement, int price_to_spawn)
        {
            this.name = name;
            this.health = health;
            this.current_health = current_health;
            this.speed_of_movement = speed_of_movement;
            this.price_to_spawn = price_to_spawn;
        }

        public override void Take_damage()
        {
            throw new System.NotImplementedException();
        }
        public  IWeapon weapon { get; set; }

        public void Update()
        {
            //slider_hp.transform.position = Camera.main.
            ChangeLevelSliderHP();
        }


        private void ChangeLevelSliderHP()
        {
            slider_hp.minValue = 0;
            slider_hp.maxValue = health;
            slider_hp.value = currentHealth;
        }

        public override void Display_information()
        {
            throw new System.NotImplementedException();
            // $" Name: {Name}
            // Health: {Health}
            // Price to unlock: {Price}
            // Damage: 
        }
       // private IWeapon bile = new PoisonousBile("Bile",  8,  3,  4);
    }
}
