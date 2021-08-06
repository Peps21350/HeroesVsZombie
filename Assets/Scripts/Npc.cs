using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
   public abstract class Npc
   {
      protected string name { get; set; }
      protected float health { get; set; }

      protected float speedOfMovement { get; set; }

      public abstract IWeapon weapon { get; set; }
      protected float currentHealth { get; set; }

      protected int priceToUnlock { get; set; }

      protected Npc(string name, float health, float currentHealth,float speedOfMovement)
      {
         this.name = name;
         this.health = health;
         this.currentHealth = currentHealth;
         this.speedOfMovement = speedOfMovement;
      }

      public abstract void Give_damage();
      public abstract void Take_damage();
      public abstract void Display_information();
   }
}