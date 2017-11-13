using System.Linq;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    Dictionary<string, KeyCode> buttonKeys;

    void OnEnable()
    {
        buttonKeys = new Dictionary<string, KeyCode>();
        buttonKeys["Up"] = KeyCode.UpArrow;
        buttonKeys["Down"] = KeyCode.DownArrow;
        buttonKeys["Left"] = KeyCode.LeftArrow;
        buttonKeys["Right"] = KeyCode.RightArrow;
    }

	// Use this for initialization
	void Start ()
    {
    }
	
    public bool GetButtonPressed(string buttonName)
    {
        if (buttonKeys.ContainsKey(buttonName) == false)
        {
            Debug.Log("'" + buttonName + "'" + "does not exists");
            return false;
        }

        return Input.GetKeyDown(buttonKeys[buttonName]);
    }

    public bool GetButtonDown(string buttonName)
    {
        if (buttonKeys.ContainsKey(buttonName) == false)
        {
            Debug.Log( "'" + buttonName + "'" + "does not exists");
            return false;
        }

        return Input.GetKey(buttonKeys[buttonName]);
    }

    public List<string> GetButtonsNames()
    {
        return buttonKeys.Keys.ToList();
    }

    public string GetKeyNameFromButton(string buttonName )
    {
        if (buttonKeys.ContainsKey(buttonName) == false)
        {
            Debug.Log("'" + buttonName + "'" + "does not exists");
            return "_NO_KEY_";
        }

        return buttonKeys[buttonName].ToString();
    }

    public void SetNewKey ( string buttonName, KeyCode keyCode)
    {
        buttonKeys[buttonName] = keyCode;
    }
}
