using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
   public class Npc : MonoBehaviour
   {
      public event Action<float> onHealthChange = delegate {};

      public Slider slider_hp;

      public bool is_enemy = false;
      
      protected string name { get; set; }
      
      [SerializeField] protected float health;
      public float healthProperty =>health;

      [SerializeField] protected float attack_damage;
      public virtual float attackDamage => attack_damage + weapon?.damage ?? 0;


      [SerializeField] protected float speed_of_movement;
      public float speedOfMovement => speed_of_movement;


      public IWeapon weapon { get; set; }

      
      [SerializeField] public float current_health;
      
      public float currentHealth => current_health;

      [SerializeField] protected int price_to_unlock;

      public int priceToUnlock => price_to_unlock;

      [SerializeField] protected int price_to_spawn;
      public int priceToSpawn => price_to_spawn;
      
      

      protected Npc()
      {
      }

      public void init(string name, float health,float speed_of_movement, int price_to_spawn, int price, IWeapon weapon, bool is_enemy = false)
      {
         this.name = name;
         this.health = health;
         current_health = health;
         this.speed_of_movement = speed_of_movement;
         this.price_to_spawn = price_to_spawn;
         price_to_unlock = price;
         this.is_enemy = is_enemy;
         this.weapon = weapon;
      }

      private void OnCollisionEnter2D(Collision2D other)
      {
         if (other.gameObject.CompareTag("Npc"))
         {
            Npc npc_component = other.gameObject.GetComponent<Npc>();
            npc_component.GetComponent<Rigidbody2D>().velocity = Vector2.one;
         }
         
         if (other.gameObject.CompareTag("FinishForZombie"))
         {
            Npc npc_component = other.gameObject.GetComponent<Npc>();
            Debug.Log("вивід вікна про поразку");
            GameManager.instance.Open(false,false);
         }
      }

      private void OnCollisionExit2D(Collision2D other)
      {
         Npc npc_component = other.gameObject.GetComponent<Npc>();
         if (!is_enemy)
            npc_component.GetComponent<Rigidbody2D>().AddForce(new Vector2(-Time.deltaTime * npc_component.speedOfMovement ,0));
         else
            npc_component.GetComponent<Rigidbody2D>().AddForce(new Vector2(Time.deltaTime * npc_component.speedOfMovement,0));
      }



      // private void DestroyNPC()
      // {
      //    Npc npc_component = gameObject.GetComponent<Npc>();
      //    if(npc_component.transform.position.x > 1700 || npc_component.transform.position.x < 30 )
      //       Destroy(npc_component);
      // }


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

      private void Start()
      {
         onHealthChange(health);
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
         onHealthChange(health);
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