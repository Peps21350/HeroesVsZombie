using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace DefaultNamespace
{
    public class NpcSpawner : MonoBehaviour
    {
        
        public GameObject[] infantryman;
        public GameObject[] robot;
        private bool state_spawn = false;
        private bool type_npc;
        private bool is_infantryman = false; 
        private int number_npc;
        public static float all_health = 0; 
        [NonReorderable] private  List<NpcInfantryman> created_infantryman = new List<NpcInfantryman>();
        [NonReorderable] private List<NpcRobot> created_robot = new List<NpcRobot>();
        private GameManager gm = new GameManager();


        public void ClickOnButtonWithNPC()
        {
            number_npc = 1;
            state_spawn = true;
            gm.ShowButtonsSpawn(true);
        }
        public void ClickOnButtonWithNPC2()
        {
            number_npc = 2;
            state_spawn = true;
            gm.ShowButtonsSpawn(true);
            
        }
        
        public void OnButtonClickInfantryman()
        {
            is_infantryman = true;
        }
        
         private void SpawnInfantryman(Vector3 coords_spawn, int number_npc)
        {
            if (number_npc == 1)
            {
                GameManager.count_coins -= 10;
                GameManager.timer = GameManager.count_coins / 2;
                Spawn<NpcInfantryman>(coords_spawn,infantryman,0,"Infantryman", 75,400000,10,0,created_infantryman);
            }
            else
            {
                GameManager.count_coins -= 35;
                GameManager.timer = GameManager.count_coins / 2;
                Spawn<NpcInfantryman>(coords_spawn,infantryman,1,"Infantryman Hard", 150,300000,35,60,created_infantryman);
            }

        }
        
        private void SpawnRobot(Vector3 coords_spawn, int number_npc)
        {
            if (number_npc == 1)
            {
                GameManager.count_coins -= 15;
                GameManager.timer = GameManager.count_coins / 2;
                Spawn<NpcRobot>(coords_spawn, robot, 0, "Robot1", 90, 400000, 15, 15, created_robot);
            }
            else
            {
                GameManager.count_coins -= 25;
                GameManager.timer = GameManager.count_coins / 2;
                Spawn<NpcRobot>(coords_spawn,robot,1,"Robot2", 50,400000,25,30,created_robot);
            }

        }
        
        public void SpawnNPCUp()
        {
            if (state_spawn)
            {
                Vector3 result = new Vector3(250f, 554f, 0);
                if(is_infantryman)
                    SpawnInfantryman(result,number_npc);
                else
                    SpawnRobot(result,number_npc);
                is_infantryman = false;
                gm.ShowButtonsSpawn(false);
            }
            state_spawn = false;

        }
        
        public void SpawnNPCMidle()
        {
            if (state_spawn)
            {
                Vector3 result = new Vector3(250f, 420f, 0);
                if(is_infantryman)
                    SpawnInfantryman(result,number_npc);
                else
                    SpawnRobot(result,number_npc);
                is_infantryman = false;
                gm.ShowButtonsSpawn(false);
            }
            state_spawn = false;
        }
        
        public void SpawnNPCDown()
        {
            if (state_spawn)
            {
                Vector3 result = new Vector3(250f, 290f, 0);
                if(is_infantryman)
                    SpawnInfantryman(result,number_npc);
                else
                    SpawnRobot(result,number_npc);
                is_infantryman = false;
                gm.ShowButtonsSpawn(false);
            }
            state_spawn = false;
        }
        
        
        public void Spawn<T>(Vector3 result_coords,GameObject[] mass_game_objects,int number_of_hero, string name_hero,float health, float speed, int price_to_spawn, int price, List<T> list) where  T : Npc
        {
            T new_hero = Instantiate(mass_game_objects[number_of_hero], result_coords, Quaternion.identity).GetComponent<T>();
            new_hero.transform.localScale = new Vector3(mass_game_objects[number_of_hero].transform.localScale.x, mass_game_objects[number_of_hero].transform.localScale.y, 1);
            switch (number_of_hero)
            {
                case 0: 
                    new_hero.init(name_hero, health,speed,price_to_spawn,price);
                    break;
                case 1:
                    new_hero.init(name_hero, health,speed,price_to_spawn,price);
                    break;
            }
            new_hero.GetComponent<Rigidbody2D>().AddForce(new Vector2(Time.deltaTime * new_hero.speedOfMovement,0));
            new_hero.onHealthChange += _ => AllHPNPC();
            list.Add(new_hero);
        }
        

        private float AllHPNPC()
        {
            //float all_health = 0;
            float all_health_infantryman = 0;
            float all_health_robot = 0;
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

            return all_health = all_health_infantryman + all_health_robot;

        }
        
    }
}