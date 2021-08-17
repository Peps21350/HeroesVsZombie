using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.UI;

public class ZombieMechanics : MonoBehaviour
{

    public GameObject[] arrayZombies;
    [NonReorderable]private List<NpcZombie> createdZombies = new List<NpcZombie>();
    public Text textHealth;
    private Vector3 result;
    
    public int countZombies;


    private void Start()
    {
        CreatingZombie();
        ZombieMovement();
    }
    
    public Vector3 ZombieSpawn()
    {
        int randLocations = Random.Range(0, 3);
        int randomCoordinates = Random.Range(1, 20);
        if (randLocations == 0)
        {
            result = new Vector3(1600f, 554f, 0) - new Vector3(randomCoordinates, 0 ,0);
        }
        if (randLocations == 1)
        {
            result = new Vector3(1600f, 435f, 0) - new Vector3(randomCoordinates, 0, 0);
        }
        if (randLocations == 2)
        {
            result = new Vector3(1600f, 294f, 0) - new Vector3(randomCoordinates, 0, 0);
        }

        return result;
    }

    public void CreatingZombie()
    {
        for (int i = 0; i < countZombies; i++)
        {
            int rand = Random.Range(0, arrayZombies.Length);
            NpcZombie new_zombie = Instantiate(arrayZombies[rand], ZombieSpawn(), Quaternion.identity).GetComponent<NpcZombie>();
            new_zombie.transform.localScale = new Vector3(15, 15, 1);
            new_zombie.onHealthChange += _ => AllHPZombies();

            switch (rand)
            {
                case 0:
                    new_zombie.init("usually", 90,100000,0,0,true);
                    break;
                case 1:
                    new_zombie.init("hard", 120,70000,0,0,true);
                    break;
            }
            
            createdZombies.Add(new_zombie);
        }
    }
    

    public void ZombieMovement()
    {
        for (int i = 0; i < countZombies; i++)
        {
            createdZombies[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(-Time.deltaTime * createdZombies[i].speedOfMovement ,0));
            
        }
    }
    
    public void AllHPZombies()
    {
        float all_health = 0;
        foreach (var zombie in createdZombies)
        {
            all_health += zombie.currentHealth;
        }
        textHealth.text = $"{(int)all_health}";
    }
}
