using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextBoxControl : MonoBehaviour {
    public InputField inputField;

    public void OnEndEdit(string s)
    {
        Debug.Log("Attempting to change name to: " + s);
        PersistenceManager.instance.setName(s);
    }
}
