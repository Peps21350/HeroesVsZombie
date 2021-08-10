using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.UI;

public class ZombieMechanics : NpcZombie
{

    public GameObject[] arrayZombies;
    private NpcZombie[] createdZombies;
    public Text textHealth;
    
    public int countZombies;
    //public int levelOfDifficulty;

    private Rigidbody rb;
    //private NpcZombie zombie1 = new NpcZombie("ordinary zombie", 20f,20f,20f,0);
    

   
    private void Start()
    {
        //ZombieSpawn();
        CreatingZombie();
        ZombieMovement(true);
    }

    private void Update()
    {
        AllHPZombies();
        CheckEndMovement();
    }

    public Vector3 ZombieSpawn()
    {
        int randLocations = Random.Range(0, 2);
        int randomCoordinates = Random.Range(1, 20);
        if (randLocations == 0)
        {
            return new Vector3(1600f, 554f, 0) - new Vector3(randomCoordinates, 0 ,0);
        }
        if (randLocations == 1)
        {
            return new Vector3(1600f, 435f, 0) - new Vector3(randomCoordinates, 0, 0);
        }
        else
        {
            return new Vector3(1600f, 294f, 0) - new Vector3(randomCoordinates, 0, 0);
        }
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
                createdZombies[i].init("usually", 90,90,100000,0);
            }
            if (rand == 1)
            {
                createdZombies[i] = Instantiate(arrayZombies[1], ZombieSpawn(), Quaternion.identity).GetComponent<NpcZombie>();
                createdZombies[i].transform.localScale = new Vector3(15, 15, 1);
                createdZombies[i].init("usually", 120,120,70000,0);
            }

            
        }
    }

    private void CheckEndMovement()
    {
        foreach (var mobs in createdZombies)
        {
            if (mobs.transform.position.x == 250)
            {
                ZombieMovement(false);
                GameManager.EndGame();
            }
        }
    }

    public void ZombieMovement(bool state_movement)
    {
        if (state_movement)
        {
            for (int i = 0; i < countZombies; i++)
            {
                createdZombies[i].GetComponent<Rigidbody>().AddForce(-Time.deltaTime * createdZombies[i].speedOfMovement,0,0);
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
