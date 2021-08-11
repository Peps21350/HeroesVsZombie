using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
   public class Npc : MonoBehaviour
   {
      public Slider slider_hp;

      public bool is_enemy = false;
      
      protected string name { get; set; }
      
      [SerializeField] protected float health;
      public float healthProperty =>health;

      [SerializeField] protected float attack_damage;
      public virtual float attackDamage => attack_damage + weapon?.damage ?? 0;


      [SerializeField] protected float speed_of_movement;
      public float speedOfMovement => speed_of_movement;


      public virtual IWeapon weapon { get; set; }

      
      [SerializeField] protected float current_health;
      
      public float currentHealth => current_health;

      [SerializeField] protected int price_to_unlock;

      public int priceToUnlock => price_to_unlock;

      [SerializeField] protected int price_to_spawn;
      public int priceToSpawn => price_to_spawn;
      
      

      protected Npc()
      {
      }

      public virtual void init(string name, float health,float speed_of_movement, int price_to_spawn, int price, bool is_enemy = false)
      {
         this.name = name;
         this.health = health;
         this.current_health = health;
         this.speed_of_movement = speed_of_movement;
         this.price_to_spawn = price_to_spawn;
         price_to_unlock = price;
         this.is_enemy = is_enemy;
      }

      private void OnCollisionStay2D(Collision2D other)
      {
         if (other.gameObject.CompareTag("Npc"))
         {
            Npc npc_component = other.gameObject.GetComponent<Npc>();
            if (npc_component == null || npc_component.is_enemy == is_enemy)
               return;
            
            npc_component.Take_damage( attackDamage * Time.deltaTime );
         }
      }
      

      public void Take_damage( float damage_amount )
      {
         current_health -= damage_amount;
         if (current_health < 0)
         {
            current_health = 0;
            Destroy(gameObject);
            return;
         }

         updateHealthUI();
         //doDead();
      }
      
      private void updateHealthUI()
      {
         slider_hp.minValue = 0;
         slider_hp.maxValue = health;
         slider_hp.value = current_health;
      }

      public virtual void Display_information()
      {
         
      }
   }
}