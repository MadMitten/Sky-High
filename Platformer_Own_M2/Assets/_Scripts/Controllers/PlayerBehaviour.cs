using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour instance = null;
    public GameObject playerPrefab;
    Vector3 worldSpawn = new Vector3();
   
    void Awake()
    {
        singleton();
    }

    private void Start()
    {
        setWorldSpawn();
        newPlayer();
    }

    private void setWorldSpawn()
    {
        worldSpawn = GameObject.Find("World Spawn").transform.position;
    }

    public void newPlayer()
    {
        if(GameBehaviour.instance.checkpointHit == true)
        {
            worldSpawn = GameObject.Find("Checkpoint").transform.position;
            checkpointBehavior.instance.checkpointStart();
            //checkpointBehavior.instance.changeIcon();
            
        }
        Instantiate(playerPrefab, worldSpawn, Quaternion.identity);
    }

    void singleton() //will allow access to other scripts
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of player behavior.
            Destroy(gameObject);
        }
    }
}
