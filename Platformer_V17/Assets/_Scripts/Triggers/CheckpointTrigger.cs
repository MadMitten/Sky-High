using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    GameObject worldSpawn;
    public GameObject redFlag;
    public GameObject greenFlag;
    public GameObject[] collectables;
    public bool needsKey = true;

    private void Start()
    {
        greenFlag.SetActive(false);
        worldSpawn = GameObject.Find("World Spawn");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (needsKey)
        {
            if (GameBehaviour.instance.getKey())
            {
                checkpointHit();
            }
        } else
        {
            checkpointHit();
        }
    }

    private void checkpointHit()
    {
        //Move World Spawn
        worldSpawn.transform.position = gameObject.transform.position;
        //Destroy previous collectibles
        if (collectables != null)
        {
            foreach (GameObject collectableSet in collectables)
            {
                collectableSet.SetActive(false);
            }
        }
        //Change flag color
        redFlag.SetActive(false);
        greenFlag.SetActive(true);

        //Switch Checkpoint in game behaviour
        GameBehaviour.instance.checkpoint();
    }
}
