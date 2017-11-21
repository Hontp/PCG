using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public struct JoyButtons
{
    public string ButtonName;
    public float Value; 
}

public class InputManager : MonoBehaviour
{
    Dictionary<string, KeyCode> buttonKeys;
    UnityInput rawController;

    

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
        rawController = ScriptableObject.CreateInstance<UnityInput>();
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

    public Vector3 GetThumbStickDirection()
    {
        if (rawController.ControllerAxis.x > 0)
        {
            return Vector3.right;
        }

        if (rawController.ControllerAxis.x < 0)
        {
            return Vector3.left;
        }

        if (rawController.ControllerAxis.y > 0)
        {
            return Vector3.up;
        }

        if (rawController.ControllerAxis.y < 0)
        {
            return Vector3.down;
        }

        return Vector3.zero;
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
