using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    public Text[] names;
    public Text[] scores;

    public Text[] namesTime;
    public Text[] times;

    public GameObject casual;
    public GameObject speedRun;

    Leaderboard leaderboard;

    void Start()
    {    
        getValues();
        switchBoards(0);
    }

    public void switchBoards(int index)
    {
        if(index == 0)
        {
            casual.SetActive(true);
            speedRun.SetActive(false);
        } else
        {
            casual.SetActive(false);
            speedRun.SetActive(true);
        }
    }

    void getValues()
    {
        for (int i = 0; i < PersistenceManager.instance.lb.names.Length; i++)
        {
            names[i].text = PersistenceManager.instance.lb.names[i];
            scores[i].text = "" + PersistenceManager.instance.lb.scores[i];

            namesTime[i].text = PersistenceManager.instance.lb.namesTime[i];
            times[i].text = stringifyTime(PersistenceManager.instance.lb.times[i]);
        }
    }

    string stringifyTime(float timer)
    {
        string timeToString ="";
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60);
        string sec = "";
        if(seconds <=9)
        {
            sec = "0" + seconds;
        } else
        {
            sec = seconds + "";
        }

        timeToString = "0" + minutes + ":" + sec;

        return timeToString;
    }
}
