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

    KeyData data;
    bool isLoaded = false;

    void OnEnable()
    {
        if (isLoaded == true)
            return;

        rawController = ScriptableObject.CreateInstance<UnityInput>();
        data = ScriptableObject.CreateInstance<KeyData>();

        string playerConfig = JsonHelper.LoadSaveData("player.cfg");

        if (playerConfig != "none")
        {
            data.LoadConfig(playerConfig);

            isLoaded = true;
        }
        else
        {
            data = Resources.Load<KeyData>("Devices/keyboard");

            isLoaded = true;            
        }
    }
    // Use this for initialization
    void Start()
    {
        keys = new Dictionary<string, KeyCode>();

        for (int i = 0; i < data.buttonKeys.Count; ++i)
        {
            keys.Add(data.buttonKeys[i].Name, data.buttonKeys[i].Code);
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

    public void SavePlayerSettings()
    {
       JsonHelper.WriteSaveData("player.cfg" ,data.SaveKeyData());
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
        
        for (int i =0; i < data.buttonKeys.Count; ++i)
        {
            if (data.buttonKeys[i].Name == buttonName)
            {
                data.buttonKeys[i].Code = keyCode;
            }
        }       
    }
}
