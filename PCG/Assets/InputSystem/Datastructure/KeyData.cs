using System;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(fileName = "Control", menuName ="Barrel/ControlScheme/Control", order = 1)]
[Serializable]
public class KeyData : ScriptableObject
{

    [SerializeField] public List<Data> buttonKeys = new List<Data>();
    
    public void SetKeys(string keyName, KeyCode keyCode)
    {

        for (int i =0; i < buttonKeys.Count; ++i)
        {
            if (buttonKeys[i].Name != keyName)
            {
                buttonKeys.Add(new Data(keyName, keyCode));
                break;
            }
        }
    } 
}