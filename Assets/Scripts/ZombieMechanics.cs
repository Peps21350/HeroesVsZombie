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
    [NonReorderable]private NpcZombie[] createdZombies;
    public Text textHealth;
    private Vector3 result;
    
    public int countZombies;


    private void Start()
    {
        //ZombieSpawn();
        CreatingZombie();
        ZombieMovement(true,1);
    }

    private void Update()
    {
        AllHPZombies();
        //CheckEndMovement();
    }

    public Vector3 ZombieSpawn()
    {
        int randLocations = Random.Range(0, 2);
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
        createdZombies = new NpcZombie[countZombies];
        for (int i = 0; i < countZombies; i++)
        {
            int rand = Random.Range(0, arrayZombies.Length);
            
            if (rand == 0)
            {
                createdZombies[i] = Instantiate(arrayZombies[0], ZombieSpawn(), Quaternion.identity).GetComponent<NpcZombie>();
                createdZombies[i].transform.localScale = new Vector3(15, 15, 1);
                createdZombies[i].init("usually", 90,100000,0,0,true);
            }
            if (rand == 1)
            {
                createdZombies[i] = Instantiate(arrayZombies[1], ZombieSpawn(), Quaternion.identity).GetComponent<NpcZombie>();
                createdZombies[i].transform.localScale = new Vector3(15, 15, 1);
                createdZombies[i].init("usually", 120,70000,0,0,true);
            }

            
        }
    }
    

    public void ZombieMovement(bool state_movement,float speed)
    {
        if (state_movement)
        {
            for (int i = 0; i < countZombies; i++)
            {
                createdZombies[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(-Time.deltaTime * createdZombies[i].speedOfMovement * speed,0));
            }
        }
        else
        {
            for (int i = 0; i < countZombies; i++)
            {
                createdZombies[i].enabled = state_movement;
            }
        }
    }
    
    private void AllHPZombies()
    {
        float allHealth = 0;
        foreach (var zombie in createdZombies)
        {
            allHealth += zombie.currentHealth;
        }

        textHealth.text = $"{allHealth}";
    }
}
