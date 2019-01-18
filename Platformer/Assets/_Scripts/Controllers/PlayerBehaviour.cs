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
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
        //Sets this to not be destroyed when reloading scene
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        newPlayer();
        setWorldSpawn();
    }

    private void setWorldSpawn()
    {
        worldSpawn = GameObject.Find("World Spawn").transform.position;
    }

    public void newPlayer()
    {
        setWorldSpawn();
        Instantiate(playerPrefab, worldSpawn, Quaternion.identity);
   
    }
}
