using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBehaviour : MonoBehaviour
{
    public static GameBehaviour instance = null;
   
    int coins = 0;
    int lives = 5;
    public int currentLevel = 1;
    int nextLifeCost = 4;
    bool hasKey = false;
    int coinsThisRun = 0;
    bool checkpointHit = false;
    int currentCheckpoint = 0;
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
        DontDestroyOnLoad(gameObject);
    }

    public void restartLevel()
    {
        coins = 0;
        lives = 5;
        hasKey = false;
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
        
        if(!checkpointHit)
        {
            hasKey = false;
            SceneController.instance.changeScene(currentLevel);
        } else
        {

        }
    }

    public void reset()
    {
        coins = 0;
        lives = 5;
        currentLevel = 1;
        hasKey = false;
    }
    
    public void loseLife()
    {
        if (lives==0)
        { //if dead dead
            //PlayerBehaviour.instance.newPlayer();
            lose();
        } else
        {
            PlayerBehaviour.instance.newPlayer();
            nextLife();
            lives--;
            UIController.instance.updateUI();
        }
    }
    
    public void win()
    {
        currentLevel++;
        hasKey = false;
        SceneController.instance.nextLevel(currentLevel);
    }

    public void lose()
    {
        Debug.Log("You Lose!");
        restartLevel();
    }

    public void levelEnd()
    {
        Debug.Log("Level has ended!");
        SceneController.instance.changeScene(0);
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
    ///
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

    public int getLives()
    {
        return lives;
    }

    public int getCoins()
    {
        return coins;
    }

    public void checkpoint()
    {
        currentCheckpoint++;
        checkpointHit = true;
    }

    public void addLife()
    {
        lives++;
        changeLivesText();
    }
}
