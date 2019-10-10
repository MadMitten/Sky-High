using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameBehaviour : MonoBehaviour
{
    public static GameBehaviour instance = null;
   
    int coins = 0;
    int lives = 5;
    public int currentLevel = 1;
    int nextLifeCost = 4;
    bool hasKey = false;
    [HideInInspector]
    public bool paused = false;
    [HideInInspector]
    public bool checkpointHit = false;
    public float checked_time;
    public float checked_mins;
    int coinsThisRun = 0;


    void Awake()
    {
        singleton();
    }

    public void pauseEverything()
    {
        paused = true;
        Debug.Log("Paused: " + paused);
        //block movement on:
        //cannons#
        //coins#
        //pendulums# 
        //enemies, and 
        //player#
        //freeze timer
    }

    public void unpauseEverything()
    {
        paused = false;
        UIController.instance.updateUI();
    }

    public void lifeDecrease()
    {
        lives++;
        UIController.instance.updateUI();
    }

    private void singleton()
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
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
       //PersistenceManager.instance.leaderboardLoad();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 6)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                if (paused == false)
                {
                    paused = true;
                    UIController.instance.updateUI();
                }
            }
        }
    }

    public void restartLevel()
    {
        coins = 0;
        lives = 5;
        hasKey = false;
        checkpointHit = false;
        SceneController.instance.changeScene(currentLevel);
    }

    void nextLife()
    {
        if (coins < nextLifeCost)
        {
            coins = 0;
        }
        else
        {
            coins -= nextLifeCost;
        }
    }

    public void loseLife()
    {
        if (lives==0)
        { //if dead dead
            lose();
        } else
        {
        //    Debug.Log("Here");
           // PlayerBehaviour.instance.newPlayer();
            nextLife();
            lives--;
            UIController.instance.updateUI();
            SceneController.instance.changeScene(currentLevel + SceneController.instance.offset);
        }
    }

    public void reset()
    {
        coins = 0;
        lives = 5;
        currentLevel = 1;
        hasKey = false;
    }

    public void win()
    {
        //update score
        LevelScore ls = new LevelScore(coins, ((TimerBehaviour.instance.timer)+(TimerBehaviour.instance.minutes*60f)));
        PersistenceManager.instance.levelCompleted(currentLevel, ls);
        checkpointHit = false;
        //change level
        currentLevel++;
        hasKey = false;
        
        if(PersistenceManager.instance.data.completedLevels<SceneController.instance.getLastLevel())
        {
            PersistenceManager.instance.data.completedLevels++;
        }

        SceneController.instance.nextLevel(currentLevel);
    }

    public void lose()
    {
        //Change to scene with game over scene
        int gameOverScene = 3;
        reset();
        PersistenceManager.instance.runOver(true);
        SceneController.instance.changeScene(gameOverScene);
       // ConclusionControl.instance.changeText(false);
    }

	public void quitToMain()
	{
		reset ();
		PersistenceManager.instance.runOver(true);
		SceneController.instance.backToMain ();
	}

    public void levelEnd()
    {
        //Debug.Log("You died died, or you completed all levels... dunno which");
        PersistenceManager.instance.runOver(false);
        SceneController.instance.changeScene(3);
    }

    public void addCoin()
    {
        coins++;
        coinsThisRun++;
        UIController.instance.updateUI();
    }

    private void changeLivesText()
    {
        UIController.instance.updateUI();
    }

    ////////////// GETTERS AND SETTERS
    //
    public bool getKey()
    {
        return hasKey;
    }

    public void keyTrue()
    {
        hasKey = true;
    }

    public int getCurrentLevel()
    {
        return currentLevel;
    }

    public void setCurrentLevel(int level)
    {
        currentLevel = level;
    }

    public int getLives()
    {
        return lives;
    }

    public int getCoins()
    {
        return coins;
    }

    public void addLife()
    {
        lives++;
        changeLivesText();
    }
}
