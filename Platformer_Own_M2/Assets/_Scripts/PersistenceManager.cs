using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager instance = null;
    public PersistentData data;
    public Leaderboard lb;
    LeadboardSaver saver;
    public ScoreTracker scoreTracker;

    private void Awake()
    {
        //Create a singleton
        if(instance==null)
        {
            instance = this;
        } else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    
    private void Start()
    {
        newGame();
    }

    public void leaderboardLoad()
    {
        try
        {
            lb = saver.loadBoard();
        }
        catch (System.Exception)
        {
            Debug.Log("No Leaderboard");
        }

        if(lb==null)
        {
            lb = new Leaderboard();
        }
    }

    public void levelCompleted(int lev, LevelScore ls)
    {
        data.levelScores.Insert(lev, ls);
        scoreTracker.calculateScore(ls);
    }

    public void checkLeaderboard()
    {
        if(lb==null)
        {
            Debug.Log("Leaderboard does not exist");
        }
    }

    public void runOver(bool fromDeath)
    {
        if(lb==null)
        {
            Debug.Log("No leaderboard");
            leaderboardLoad();
            if(lb==null)
            {
                Debug.Log("WTF!?");
            }
        }

        if(scoreTracker == null)
        {
            Debug.Log("No score tracker");
        }


        if(lb.isHighScore(scoreTracker.getScore())==true)
        {
            lb.addScore(data.name, scoreTracker.getScore());
        }

        if (fromDeath == false)
        {
            if (lb.isFastestTime(scoreTracker.getTime())==true)
            {
                lb.addTime(data.name, scoreTracker.getTime());
            }
        }
        scoreTracker.resetScore();

    }

    public void setName(string n)
    {
        if(data == null)
        {
           Debug.Log("No Data?");
        }
        data = new PersistentData();
        data.name = n;
        scoreTracker.resetScore();

        Debug.Log("Data.name has been set to: " + data.name);
    }

    public void save()
    {
        saver.saveBoard(lb);
    }

    public void newGame()
    {
        data = new PersistentData();
        scoreTracker = new ScoreTracker();
        saver = new LeadboardSaver();
        leaderboardLoad();
        testPersistence();
    }

    private void testPersistence()
    {
        if(data == null)
        {
            Debug.Log("Persistent Data is null");
        }
        if (scoreTracker == null)
        {
            Debug.Log("Score tracker is null");
        }
        if (saver == null)
        {
            Debug.Log("LbSaver is null");
        }
        if (lb == null)
        {
            Debug.Log("Leaderboard is null");
        }
    }


}
