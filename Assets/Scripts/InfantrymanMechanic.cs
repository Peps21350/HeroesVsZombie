using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class InfantrymanMechanic : MonoBehaviour 
    
    {
        /*//public Button[] buttons;
        private bool state_spawn = false;
        public GameObject[] infantryman;
        [NonReorderable] private  List<NpcInfantryman> created_infantryman = new List<NpcInfantryman>();
        private int count_infantryman;

        private int number_infantryman;
        //public Text text_health_infantryman;
        private Vector3 result;
        [NonReorderable]public float allHealth = 0;
        private bool type_infantryman;
        private GameManager gm;


        private void CreatedInfantryman(Vector3 coords_spawn)
        {
            gm.Spawn<NpcInfantryman>(coords_spawn,infantryman,number_infantryman,"Infantryman", 75,400000,10,10,created_infantryman);
        }




        public void SpawnInfantrymanUp()
        {
            if (state_spawn)
            {
                result = new Vector3(250f, 554f, 0);
                //CreatingInfantryman(result);
                CreatedInfantryman(result);
                InfantrymanMovement();
            }
            state_spawn = false;

        }
        
        public void SpawnInfantrymanMidle()
        {
            if (state_spawn)
            {
                result = new Vector3(250f, 420f, 0);
                CreatingInfantryman(result);
                InfantrymanMovement();
            }
            state_spawn = false;
        }
        
        public void SpawnInfantrymanDown()
        {
            if (state_spawn)
            {
                result = new Vector3(250f, 290f, 0);
                CreatingInfantryman(result);
                InfantrymanMovement();
            }
            state_spawn = false;
        }
        
        
        public void CreatingInfantryman(Vector3 result_coords)
        {
            if (type_infantryman)
            {
                for (int i = 0; i < count_infantryman; i++)
                {
                    created_infantryman[i] = Instantiate(infantryman[0], result_coords, Quaternion.identity).GetComponent<NpcInfantryman>();
                    created_infantryman[i].transform.localScale = new Vector3(infantryman[0].transform.localScale.x, infantryman[0].transform.localScale.y, 1);
                    created_infantryman[i].init("Infantryman", 75,400000,10,10);
                    AllHPInfantryman();
                }
            }

            if (!type_infantryman)
            {
                for (int i = 0; i < count_infantryman; i++)
                {
                    //int rand = Random.Range(0, arrayZombies.Length);
                    created_infantryman[i] = Instantiate(infantryman[1], result_coords, Quaternion.identity).GetComponent<NpcInfantryman>();
                    created_infantryman[i].transform.localScale = new Vector3(infantryman[1].transform.localScale.x, infantryman[1].transform.localScale.y, 1);
                    created_infantryman[i].init("Infantryman Hard", 150,300000,35,10);
                    AllHPInfantryman();
                }
            }
        }
        
        public void InfantrymanMovement()
        {
            foreach (var infantryman_movement in created_infantryman)
            {
                infantryman_movement.GetComponent<Rigidbody2D>().AddForce(new Vector2(Time.deltaTime * infantryman_movement.speedOfMovement,0));
            }
            
        }
        

        public void ClickOnButtonsInfantryman()
        {
            number_infantryman = 1;
            type_infantryman = true;
            state_spawn = true;
            count_infantryman = +1;
        }
        
        public void ClickOnButtonsInfantryman2()
        {
            number_infantryman = 2;
            type_infantryman = false;
            state_spawn = true;
            count_infantryman = +1;
        }
        
        private void IsAlive()
        {
            foreach (var dead_infantryman in created_infantryman)
            {
                if (dead_infantryman.currentHealth <= 0)
                {
                    Destroy(dead_infantryman);
                }
            }
        }
        
        //private void Update()
        //{
        //    AllHPInfantryman();
        //    //CheckEndMovement();
        //}


        private float AllHPInfantryman()
        {
            allHealth = 0;
            if (created_infantryman[0] != null)
            {
                foreach (var infantryman in created_infantryman)
                {
                    allHealth += infantryman.currentHealth;
                }
            }
            return allHealth;
        }*/
    }
}