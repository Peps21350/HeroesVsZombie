using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class NpcSpawner : MonoBehaviour
    {
        public GameObject[] infantryman;
        public GameObject[] robot;
        public GameObject[] arrayZombies;
        [SerializeField] private GameManager gameManager;
        
        private bool _stateSpawn;
        private bool _typeNpc;
        private bool _isInfantryman; 
        private int _numberNpc;
        public static float HealthHeroes;
        public static float HealthZombie;
        [SerializeField]private int count_zombies;
        
        private List<Npc> _createdHeroes = new List<Npc>();
        [NonSerialized]public List<Npc> createdZombies = new List<Npc>();
        private List<Npc> _createdNpc = new List<Npc>();
        
        private Vector3[] _places;
        
        
        private void Start()
        {
            _places = new[]{new Vector3(1750f, 554f, 0),new Vector3(1750f, 420f, 0), new Vector3(1750f, 290f, 0)};
            SpawnZombie(count_zombies);
        }


        public void ClickOnButtonWithNPC()
        {
            _numberNpc = 1;
            _stateSpawn = true;
            gameManager.ShowButtonsSpawn(true);
        }
        public void ClickOnButtonWithNPC2()
        {
            _numberNpc = 2;
            _stateSpawn = true;
            gameManager.ShowButtonsSpawn(true);
            
        }
        
        public void OnButtonClickInfantryman()
        {
            _isInfantryman = true;
        }

        public void SpawnZombie(int countZombies)
        {
            for (int i = 0; i < countZombies; i++)
            {
                int rand = Random.Range(0, arrayZombies.Length);
                Vector3 newPositions = _places[Random.Range(0, _places.Length)];
                switch (rand)
                {
                    case 0:
                        Spawn(newPositions,arrayZombies,0,"Zombie", 90,9f,0,0,true,new WeaponPoisonousBile("poisonous bile", 12f, 1.5f, 2f),createdZombies);
                        break;
                    case 1:
                        Spawn(newPositions,arrayZombies,1,"Hard zombie", 120,8f,0,0,true,new WeaponPoisonousBile("poisonous bile", 14f, 2f, 2f),createdZombies);
                        break;
                }
            }
        }

        private void SpawnInfantryman(Vector3 coordsSpawn, int numberNpc)
        {
            if (numberNpc == 1)
            {
                GameManager.CountCoins -= 10;
                GameManager.GameTimer = GameManager.CountCoins / 2;
                Spawn(coordsSpawn,infantryman,0,"Infantryman", 75,10f,10,0,false,new WeaponSpear("spear", 10, 1.3f, 5f),_createdHeroes);
            }
            else
            {
                GameManager.CountCoins -= 35;
                GameManager.GameTimer = GameManager.CountCoins / 2;
                Spawn(coordsSpawn,infantryman,1,"Infantryman Hard", 150,9f,35,60,false,new WeaponSpear("spear", 12, 2f, 5f),_createdHeroes);
            }

        }
        
        private void SpawnRobot(Vector3 coordsSpawn, int numberNpc)
        {
            if (numberNpc == 1)
            {
                GameManager.CountCoins -= 15;
                GameManager.GameTimer = GameManager.CountCoins / 2;
                Spawn(coordsSpawn, robot, 0, "Robot1", 90, 10, 15, 15, false,new WeaponM4("M4",  12,  3.2f,  6),_createdHeroes);
            }
            else
            {
                GameManager.CountCoins -= 25;
                GameManager.GameTimer = GameManager.CountCoins / 2;
                Spawn(coordsSpawn,robot,1,"Robot2", 60,10,25,30,false,new WeaponM4("M4",  15,  5,  6),_createdHeroes);
            }

        }
        
        public void  SpawnNpcUp()
        {
            Vector3 result = new Vector3(150f, 554f, 0);
            if (_stateSpawn)
            {
                if(_isInfantryman)
                    SpawnInfantryman(result,_numberNpc);
                else
                    SpawnRobot(result,_numberNpc);
                _isInfantryman = false;
                gameManager.ShowButtonsSpawn(false);
            }
            _stateSpawn = false;
        }
        
        public void SpawnNpcMidle()
        {
            Vector3 result = new Vector3(150f, 420f, 0);
            if (_stateSpawn)
            {
                if(_isInfantryman)
                    SpawnInfantryman(result,_numberNpc);
                else
                    SpawnRobot(result,_numberNpc);
                _isInfantryman = false;
                gameManager.ShowButtonsSpawn(false);
            }
            _stateSpawn = false;
        }
        
        public void  SpawnNpcDown()
        {
            Vector3 result = new Vector3(150f, 290f, 0);
            if (_stateSpawn)
            {
                if(_isInfantryman)
                    SpawnInfantryman(result,_numberNpc);
                else
                    SpawnRobot(result,_numberNpc);
                _isInfantryman = false;
                gameManager.ShowButtonsSpawn(false);
            }
            _stateSpawn = false;
        }
        
        
        public void Spawn<T>(Vector3 resultCoords,GameObject[] massGameObjects,int numberOfHero, string nameHero,float health, float speed, int priceToSpawn, int price,bool isEnemy,IWeapon weapon, List<T> list) where  T : Npc
        {
            T npc = Instantiate(massGameObjects[numberOfHero], resultCoords, Quaternion.identity).GetComponent<T>();
            npc.transform.localScale = new Vector3(massGameObjects[numberOfHero].transform.localScale.x, massGameObjects[numberOfHero].transform.localScale.y, 1);

            npc.Init(nameHero, health,speed,priceToSpawn,price,weapon,isEnemy);
            
            npc.HealthChange += _ =>   AllHpNpc();
            list.Add(npc);
            _createdNpc.Add(npc);
        }

        private void NpcMovement()
        {
            if (_createdNpc == null) return;
            foreach (var npc in _createdNpc)
            {
                if (npc == null) continue;
                float sideToMove = npc.is_enemy == false? 2f : -1;
                npc.GetComponent<Rigidbody2D>().AddForce(new Vector2(sideToMove  * npc.speedOfMovement,0));
            }
        }

        private void FixedUpdate()
        {
            NpcMovement();
        }

        public  void AllHpNpc()
        {
            //float all_health = 0;
            float allHealthHeroes = 0;
            float allHealthZombie = 0;
            if (_createdHeroes != null)
            {
                foreach (var hero in _createdHeroes)
                {
                    allHealthHeroes += hero.currentHealth;
                }
            }
            if (createdZombies != null)
            {
                foreach (var zombie in createdZombies)
                {
                    allHealthZombie+= zombie.currentHealth;
                }
            }
            HealthHeroes = allHealthHeroes;
            HealthZombie = allHealthZombie;
        }
        
    }
}