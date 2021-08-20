using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class NpcSpawner : MonoBehaviour
    {
        public static NpcSpawner instance_npc_spawner = null;
        public GameObject[] infantryman;
        public GameObject[] robot;
        public GameObject[] arrayZombies;
        private bool state_spawn;
        private bool type_npc;
        private bool is_infantryman; 
        private int number_npc;
        public static float health_heroes;
        public static float health_zombie;
        [SerializeField]private int count_zombies;
        private List<Npc> created_heroes = new List<Npc>();
        private List<Npc> created_zombies = new List<Npc>();
        
        private List<Npc> created_npc = new List<Npc>();


        private Vector3[] places;
        
        private void Start()
        {
            places = new[]{new Vector3(1750f, 554f, 0),new Vector3(1750f, 420f, 0), new Vector3(1750f, 290f, 0)};
            SpawnZombie(count_zombies);
        }
        
        public void Awake()
        {
            if ( instance_npc_spawner == null ) 
                instance_npc_spawner = this;
        }


        public void ClickOnButtonWithNPC()
        {
            number_npc = 1;
            state_spawn = true;
            GameManager.instance.ShowButtonsSpawn(true);
        }
        public void ClickOnButtonWithNPC2()
        {
            number_npc = 2;
            state_spawn = true;
            GameManager.instance.ShowButtonsSpawn(true);
            
        }
        
        public void OnButtonClickInfantryman()
        {
            is_infantryman = true;
        }

        public void SpawnZombie(int count_zombies)
        {
            for (int i = 0; i < count_zombies; i++)
            {
                int rand = Random.Range(0, arrayZombies.Length);
                Vector3 new_positions = places[Random.Range(0, places.Length)];
                switch (rand)
                {
                    case 0:
                        Spawn(new_positions,arrayZombies,0,"Zombie", 90,9f,0,0,true,new WeaponPoisonousBile("poisonous bile", 12f, 1.5f, 2f),created_zombies);
                        break;
                    case 1:
                        Spawn(new_positions,arrayZombies,1,"Hard zombie", 120,8f,0,0,true,new WeaponPoisonousBile("poisonous bile", 14f, 2f, 2f),created_zombies);
                        break;
                }
            }
        }

        private void SpawnInfantryman(Vector3 coords_spawn, int number_npc)
        {
            if (number_npc == 1)
            {
                GameManager.count_coins -= 10;
                GameManager.timer = GameManager.count_coins / 2;
                Spawn(coords_spawn,infantryman,0,"Infantryman", 75,10f,10,0,false,new WeaponSpear("spear", 10, 1.3f, 5f),created_heroes);
            }
            else
            {
                GameManager.count_coins -= 35;
                GameManager.timer = GameManager.count_coins / 2;
                Spawn(coords_spawn,infantryman,1,"Infantryman Hard", 150,9f,35,60,false,new WeaponSpear("spear", 12, 2f, 5f),created_heroes);
            }

        }
        
        private void SpawnRobot(Vector3 coords_spawn, int number_npc)
        {
            if (number_npc == 1)
            {
                GameManager.count_coins -= 15;
                GameManager.timer = GameManager.count_coins / 2;
                Spawn(coords_spawn, robot, 0, "Robot1", 90, 10, 15, 15, false,new WeaponM4("M4",  12,  3.2f,  6),created_heroes);
            }
            else
            {
                GameManager.count_coins -= 25;
                GameManager.timer = GameManager.count_coins / 2;
                Spawn(coords_spawn,robot,1,"Robot2", 60,10,25,30,false,new WeaponM4("M4",  15,  5,  6),created_heroes);
            }

        }
        
        public void  SpawnNPCUp()
        {
            Vector3 result = new Vector3(250f, 554f, 0);
            if (state_spawn)
            {
                if(is_infantryman)
                    SpawnInfantryman(result,number_npc);
                else
                    SpawnRobot(result,number_npc);
                is_infantryman = false;
                GameManager.instance.ShowButtonsSpawn(false);
            }
            state_spawn = false;
        }
        
        public void SpawnNPCMidle()
        {
            Vector3 result = new Vector3(250f, 420f, 0);
            if (state_spawn)
            {
                if(is_infantryman)
                    SpawnInfantryman(result,number_npc);
                else
                    SpawnRobot(result,number_npc);
                is_infantryman = false;
                GameManager.instance.ShowButtonsSpawn(false);
            }
            state_spawn = false;
        }
        
        public void  SpawnNPCDown()
        {
            Vector3 result = new Vector3(250f, 290f, 0);
            if (state_spawn)
            {
                if(is_infantryman)
                    SpawnInfantryman(result,number_npc);
                else
                    SpawnRobot(result,number_npc);
                is_infantryman = false;
                GameManager.instance.ShowButtonsSpawn(false);
            }
            state_spawn = false;
        }
        
        
        public void Spawn<T>(Vector3 result_coords,GameObject[] mass_game_objects,int number_of_hero, string name_hero,float health, float speed, int price_to_spawn, int price,bool is_enemy,IWeapon weapon, List<T> list) where  T : Npc
        {
            T npc = Instantiate(mass_game_objects[number_of_hero], result_coords, Quaternion.identity).GetComponent<T>();
            npc.transform.localScale = new Vector3(mass_game_objects[number_of_hero].transform.localScale.x, mass_game_objects[number_of_hero].transform.localScale.y, 1);

            npc.init(name_hero, health,speed,price_to_spawn,price,weapon,is_enemy);
            
            npc.onHealthChange += _ =>   AllHPNPC();
            list.Add(npc);
            created_npc.Add(npc);
        }


        // public void ShowInformations()
        // {
        //     foreach (var hero in created_heroes)
        //     {
        //         hero.Display_information();
        //     }
        // }

        private void FixedUpdate()
        {
            if (created_npc != null)
            {
                foreach (var npc in created_npc)
                {
                    if (npc != null)
                    {
                        float side_to_move = npc.is_enemy == false? 1 : -1;
                        npc.GetComponent<Rigidbody2D>().AddForce(new Vector2(side_to_move  * npc.speedOfMovement,0));
                    }
                }
            }
        }

        public  void AllHPNPC()
        {
            //float all_health = 0;
            float all_health_heroes = 0;
            float all_health_zombie = 0;
            if (created_heroes != null)
            {
                foreach (var hero in created_heroes)
                {
                    all_health_heroes += hero.currentHealth;
                }
            }
            if (created_zombies != null)
            {
                foreach (var zombie in created_zombies)
                {
                    all_health_zombie+= zombie.currentHealth;
                }
            }
            health_heroes = all_health_heroes;
            health_zombie = all_health_zombie;
        }
        
    }
}