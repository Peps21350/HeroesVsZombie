using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
   [SerializeField] private GameManager gameManager;
   public event Action<float> HealthChange = delegate {};

   public NpcId npc_id = NpcId.None;
      
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
   
   public void Init(string name, float health,float speedOfMovement, int priceToSpawn, int price, IWeapon weapon, bool isEnemy = false)
   {
      this.name = name;
      this.health = health;
      current_health = health;
      this.speed_of_movement = speedOfMovement;
      this.price_to_spawn = priceToSpawn;
      price_to_unlock = price;
      this.is_enemy = isEnemy;
      this.weapon = weapon;
   }
   
   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.CompareTag("Npc"))
      {
         Npc npcComponent = other.gameObject.GetComponent<Npc>();
         npcComponent.GetComponent<Rigidbody2D>().velocity = Vector2.one;
      }
         
      if (other.gameObject.CompareTag("FinishForZombie"))
      {
         Npc npcComponent = other.gameObject.GetComponent<Npc>();
         gameManager.Open(false,false);
      }
   }

   private void OnCollisionExit2D(Collision2D other)
   {
      Npc npcComponent = other.gameObject.GetComponent<Npc>();
      if (!is_enemy)
         npcComponent.GetComponent<Rigidbody2D>().AddForce(new Vector2(-Time.deltaTime * npcComponent.speedOfMovement ,0));
      else
         npcComponent.GetComponent<Rigidbody2D>().AddForce(new Vector2(Time.deltaTime * npcComponent.speedOfMovement,0));
   }
      
   private void OnCollisionStay2D(Collision2D other)
   {
      if (other.gameObject.CompareTag("Npc"))
      {
         Npc npcComponent = other.gameObject.GetComponent<Npc>();
         if (npcComponent == null || npcComponent.is_enemy == is_enemy)
            return;
            
         npcComponent.TakeDamage( attackDamage * Time.deltaTime );
      }
   }

   private void Start()
   {
      HealthChange(health);
   }

   private void TakeDamage( float damageAmount )
   {
      current_health -= damageAmount;
      if (current_health < 0)
      {
         current_health = 0;
         Destroy(gameObject);
         return;
      }
      HealthChange(health);
      UpdateHealthUI();
   }

   private void UpdateHealthUI()
   {
      slider_hp.minValue = 0;
      slider_hp.maxValue = health;
      slider_hp.value = current_health;
   }
   
}
   
public enum NpcId
{
   None,
   Infantryman,
   Robot,
   Robot2,
   Infantryman2
}