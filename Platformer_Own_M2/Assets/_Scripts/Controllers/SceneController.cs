using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance = null;
    [HideInInspector]
    int lastLevel = 3;
    //offset is the level that levels start at -1.
    [HideInInspector]
    public int offset = 5;

    void Awake()
    {
        singleton();
    }

    public void changeScene(int sceneID)
    {
        if(sceneID >= 6)
        {
            if (AudioControl.instance == null)
            {

            }
            else
            {
                AudioControl.instance.destroyMenuAudio();
            }
            Debug.Log("sceneId - offset: " + (sceneID - offset));
            GameBehaviour.instance.setCurrentLevel(sceneID-offset);
        }

        SceneManager.LoadScene(sceneID);
    }

    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void nextLevel(int currentLevel)
    {
        //Debug.Log("Current Level: " + GameBehaviour.instance.getCurrentLevel() + " maxLevel: " + lastLevel);
        //Debug.Log("Psyche, current level: " + currentLevel);
        if (currentLevel>lastLevel)
        {
            Debug.Log("This is the last level, going to end");
            GameBehaviour.instance.reset();
            GameBehaviour.instance.levelEnd();
        } else
        {
            changeScene(currentLevel+offset);
        }
    }

    public int getLastLevel()
    {
        return lastLevel;
    }

    void singleton()
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
    }

	public void backToMain()
	{
		PersistenceManager.instance.save ();
		SceneController.instance.changeScene (0);
	}

    public void quitGame()
    {
        PersistenceManager.instance.save();
        Application.Quit();
    }
    
}
