using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController instance = null;
    int playerLevel = 0;
    int currentLevel = 0;


    public GameObject[] hubPoints;
    public Sprite inactive;
    public Sprite active;
    public Sprite complete;

    SpriteRenderer rend;
    int[] levels;

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

    void Start()
    {
        instance = this;
        newGame();
    }

    public void levelCompleted()
    {
        if(levels[playerLevel]!=1)
        { //not playing the same level
            levels[playerLevel] = 1;
            levels[playerLevel + 1] = 0;
            updatePoints();
            playerLevel++;
        }  
    }

    void newGame()
    {
        levelSetup();  
        updatePoints();
    }

    public int getLevel()
    {
        return currentLevel;
    }

    public void increaseLevel()
    {
        currentLevel++;
    }
    
    public void decreaseLevel()
    {
        currentLevel--;
    }

    public bool isNextLevelActive()
    {
        bool active = false;

        if (currentLevel + 1 < levels.Length)
        {
            if (levels[currentLevel+1] >= 0)
            {
                active = true;
            }
        }

        return active;
    }

    public bool isPreviousLevelActive()
    {
        bool active = false;

        if(currentLevel-1 >= 0)
        {
            if(levels[currentLevel-1] >= 0)
            {
                active = true;
            }
        }

        return active;
    }

    public void goToLevel()
    {
        SceneController.instance.changeScene(currentLevel + 2);
    }

    private void levelSetup()
    {
        //4 levels
        levels = new int[]
        {
            0,
            -1,
            -1,
            -1
        };
    }

    void updatePoints()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            rend = hubPoints[i].GetComponent<SpriteRenderer>();
            if (levels[i]==-1)
            {
                rend.sprite = inactive;
            }
            else if(levels[i]==0)
            {
                rend.sprite = active;
            }
            else if(levels[i]==1)
            {
                rend.sprite = complete;
            }
        }
    }
}
