using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance = null;
    int lastLevel = 3;

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
    }

    public void changeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void nextLevel(int currentLevel)
    {
        Debug.Log("Current Level: " + GameBehaviour.instance.getCurrentLevel() + " maxLevel: " + lastLevel);
        if (currentLevel>lastLevel)
        {
            Debug.Log("Level: " + GameBehaviour.instance.getCurrentLevel());
            GameBehaviour.instance.reset();
            Debug.Log("Level: " + GameBehaviour.instance.getCurrentLevel());
            changeScene(0);
        } else
        {
            changeScene(currentLevel);
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }
    
}
