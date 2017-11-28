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
    UnityInput rawController;
    Dictionary<string, KeyCode> keys;

    KeyData buttonKeys;

    void OnEnable()
    {
        rawController = ScriptableObject.CreateInstance<UnityInput>();

        buttonKeys = ScriptableObject.CreateInstance<KeyData>();
        buttonKeys = Resources.Load<KeyData>("Devices/keyboard");
    } 
    // Use this for initialization
    void Start ()
    {
        keys = new Dictionary<string, KeyCode>();

        for (int i = 0; i < buttonKeys.buttonKeys.Count; ++i)
        {
            keys.Add(buttonKeys.buttonKeys[i].Name, buttonKeys.buttonKeys[i].Code);
        }
    }

    public bool GetButtonPressed(string buttonName)
    {
        if ( keys.ContainsKey(buttonName) == false)
        {
            Debug.Log("'" + buttonName + "'" + "does not exists");
            return false;
        }

        return Input.GetKeyDown(keys[buttonName]);
    }

    public bool GetButtonDown(string buttonName)
    {
        if (keys.ContainsKey(buttonName) == false)
        {
            Debug.Log( "'" + buttonName + "'" + "does not exists");
            return false;
        }

        return Input.GetKey(keys[buttonName]);
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
        return keys.Keys.ToList();
    }

    public string GetKeyNameFromButton(string buttonName )
    {
        if (keys.ContainsKey(buttonName) == false)
        {
            Debug.Log("'" + buttonName + "'" + "does not exists");
            return "_NO_KEY_";
        }

        return keys[buttonName].ToString();
    }

    public void SetNewKey ( string buttonName, KeyCode keyCode)
    {
        keys[buttonName] = keyCode;
    }
}
