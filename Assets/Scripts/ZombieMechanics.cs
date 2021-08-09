using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ZombieMechanics : MonoBehaviour
{

    public GameObject[] arrayZombies;
    private GameObject createdZombies;

    public Rigidbody rb;
    //private NpcZombie zombie1 = new NpcZombie("ordinary zombie", 20f,20f,20f,0);
    

    public void ZombieMovement()
    {
        rb.AddForce(-Time.deltaTime * 100000,0,0);
        createdZombies.GetComponent<Rigidbody>().AddForce(-Time.deltaTime * 100000,0,0);
        // for (int i = 0; i < 190; i++)
        // {
        //     createdZombies.transform.position = new Vector3(createdZombies.transform.position.x - i * 1,
        //         createdZombies.transform.position.y);
        // }
    }

    private void Start()
    {
        ZombieSpawn();
        ZombieMovement();
    }

    public void ZombieSpawn()
    {
        createdZombies = Instantiate(arrayZombies[0], new Vector3(1600f, 435f, 0), Quaternion.identity) as GameObject;
        createdZombies.transform.localScale = new Vector3(20, 20, 1);
    }

    private void AllHPZombies()
    {
        
    }
}
