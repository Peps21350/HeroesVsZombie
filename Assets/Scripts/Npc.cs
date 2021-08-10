using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
   public class Npc : MonoBehaviour
   {
      public GameObject zombie_prefab;
      protected string name { get; set; }
      
      [SerializeField] protected float health;
      public float healthProperty =>health;

      [SerializeField] protected float speed_of_movement;
      public float speedOfMovement => speed_of_movement;


      public  IWeapon weapon { get; set; }
      
      [SerializeField] protected float current_health;
      
      public float currentHealth => current_health;

      [SerializeField] protected int price_to_unlock;

      public int priceToUnlock => price_to_unlock;

      [SerializeField] protected int price_to_spawn;
      public int priceToSpawn => price_to_spawn;

      protected Npc()
      {
      }

      // public void init()
      // {
      //    NpcZombie zombie = Instantiate(zombie_prefab).GetComponent<NpcZombie>();
      //    zombie.init();
      // }
      
      public virtual void init(string name, float health, float current_health,float speed_of_movement, int price_to_spawn)
      {
         this.name = name;
         this.health = health;
         this.current_health = currentHealth;
         this.speed_of_movement = speedOfMovement;
         this.price_to_spawn = priceToSpawn;
      }

      public virtual void Give_damage()
      {
         
      }

      public virtual void Take_damage()
      {
      }

      public virtual void Display_information()
      {
         
      }
   }
}