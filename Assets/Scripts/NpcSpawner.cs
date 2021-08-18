using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class NpcSpawner : MonoBehaviour
    {
        
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
        private  List<NpcInfantryman> created_infantryman = new List<NpcInfantryman>();
        private List<NpcRobot> created_robot = new List<NpcRobot>();
        private List<NpcZombie> created_zombies = new List<NpcZombie>();
        
        
        private Vector3[] places;
        
        private void Start()
        {
            places = new[]{new Vector3(1750f, 554f, 0),new Vector3(1750f, 420f, 0), new Vector3(1750f, 290f, 0)};
            SpawnZombie();
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

        private void SpawnZombie()
        {
            for (int i = 0; i < count_zombies; i++)
            {
                int rand = Random.Range(0, arrayZombies.Length);
                Vector3 new_positions = places[Random.Range(0, places.Length)];
                switch (rand)
                {
                    case 0:
                        Spawn(new_positions,arrayZombies,0,"Zombie", 90,100000,0,0,true,-1,created_zombies);
                        break;
                    case 1:
                        Spawn(new_positions,arrayZombies,1,"Hard zombie", 120,70000,0,0,true,-1,created_zombies);
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
                Spawn(coords_spawn,infantryman,0,"Infantryman", 75,600000,10,0,false,1,created_infantryman);
            }
            else
            {
                GameManager.count_coins -= 35;
                GameManager.timer = GameManager.count_coins / 2;
                Spawn(coords_spawn,infantryman,1,"Infantryman Hard", 150,400000,35,60,false,1,created_infantryman);
            }

        }
        
        private void SpawnRobot(Vector3 coords_spawn, int number_npc)
        {
            if (number_npc == 1)
            {
                GameManager.count_coins -= 15;
                GameManager.timer = GameManager.count_coins / 2;
                Spawn(coords_spawn, robot, 0, "Robot1", 90, 600000, 15, 15, false,1,created_robot);
            }
            else
            {
                GameManager.count_coins -= 25;
                GameManager.timer = GameManager.count_coins / 2;
                Spawn(coords_spawn,robot,1,"Robot2", 50,400000,25,30,false,1,created_robot);
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
        
        
        public void Spawn<T>(Vector3 result_coords,GameObject[] mass_game_objects,int number_of_hero, string name_hero,float health, float speed, int price_to_spawn, int price,bool is_enemy, int side_of_the_movement, List<T> list) where  T : Npc
        {
            T npc = Instantiate(mass_game_objects[number_of_hero], result_coords, Quaternion.identity).GetComponent<T>();
            npc.transform.localScale = new Vector3(mass_game_objects[number_of_hero].transform.localScale.x, mass_game_objects[number_of_hero].transform.localScale.y, 1);

            npc.init(name_hero, health,speed,price_to_spawn,price,is_enemy);
        
            npc.GetComponent<Rigidbody2D>().AddForce(new Vector2(side_of_the_movement * Time.deltaTime * npc.speedOfMovement,0));
            npc.onHealthChange += _ =>   AllHPNPC();
            list.Add(npc);
        }
        

        public  void AllHPNPC()
        {
            //float all_health = 0;
            float all_health_infantryman = 0;
            float all_health_robot = 0;
            float all_health_zombie = 0;
            if (created_infantryman != null)
            {
                foreach (var infantryman in created_infantryman)
                {
                    all_health_infantryman += infantryman.currentHealth;
                }
            }
            if (created_robot != null)
            {
                foreach (var robot in created_robot)
                {
                    all_health_robot += robot.currentHealth;
                }
            }
            if (created_zombies != null)
            {
                foreach (var zombie in created_zombies)
                {
                    all_health_zombie+= zombie.currentHealth;
                }
            }
            health_heroes = all_health_infantryman + all_health_robot;
            health_zombie = all_health_zombie;
        }
        
    }
}