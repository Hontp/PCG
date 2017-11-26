using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data
{
   [SerializeField] public string Name;
   [SerializeField] public KeyCode Code;

    public Data(string keyName, KeyCode keyCode)
    {
        Name = keyName;
        Code = keyCode;
    }
}
