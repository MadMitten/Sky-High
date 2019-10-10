using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuController : MonoBehaviour {
    public Button[] menuButtons;
    bool newGame = true;

	void Start ()
    {
        isNewGame();

        if (newGame)
        {
            PersistenceManager.instance.newGame();
        }

        setButtons();
        
    }

    void setButtons()
    {
        //All buttons are active and interactable at start
        if(PersistenceManager.instance.data.name.Equals(" "))
        {
            menuButtons[1].gameObject.SetActive(false);
            menuButtons[2].gameObject.SetActive(false);
        } else
        {
            //menuButtons[0].gameObject.SetActive(false);
            menuButtons[1].gameObject.SetActive(false);
        }
    }
	
    void isNewGame()
    {
        if (PersistenceManager.instance.data == null)
        {

        } else
        {
            newGame = false;
        }
    }

    void createNewGame()
    {
        //Change Level to ask for user name
        SceneController.instance.changeScene(0);
    }
}
