using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointBehavior : MonoBehaviour {
    public static checkpointBehavior instance = null;
    public GameObject[] collectibles;
    GameObject spawnPoint;
    public Sprite checkpointOn;
    bool checkpoint = false;
    [HideInInspector]
    public float checkedTime;

    [HideInInspector]
    public float checkedMins;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        spawnPoint = GameObject.Find("World Spawn");
        if(GameBehaviour.instance.checkpointHit==true)
        {
            checkpoint = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (checkpoint == false)
        {
            checkedTime = TimerBehaviour.instance.timer;
            checkedMins = TimerBehaviour.instance.minutes;

            GameBehaviour.instance.checked_time = checkedTime;
            GameBehaviour.instance.checked_mins = checkedMins;

            //remove collectibles
            Debug.Log("checkedTime: " + checkedTime);
            Debug.Log("checkedMins: " + checkedMins);
            changeIcon();
            checkpoint = true;

            checkpointStart();
            //set checkpoint hit to true
            GameBehaviour.instance.checkpointHit = true;
            //changeSprite
        }
    }

    public void changeIcon()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = checkpointOn;
    }

    public void checkpointStart()
    {
        //spawnPoint.transform.position = this.transform.position;
        for (int i = 0; i < collectibles.Length; i++)
        {
            collectibles[i].SetActive(false);
        }
        changeIcon();
        //TimerBehaviour.instance.timer = checkpointBehavior.instance.checkedTime;
        //TimerBehaviour.instance.minutes = checkpointBehavior.instance.checkedMins;
    }
}
