using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour {
    public static LevelData instance = null;

    public int levels;

    private void Awake()
    {
        singleton();
    }

    private void Start()
    {
        levels = 0;
    }

    private void singleton()
    {
        // Check if instance already exists
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
    }
}
