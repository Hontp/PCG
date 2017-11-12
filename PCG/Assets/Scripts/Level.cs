using UnityEngine;
using System.Collections.Generic;

public class Level : MonoBehaviour
{
    Dictionary<string, Random.State> levelStorage = new Dictionary<string, Random.State>();


    public void SaveLevel(string lvlName ,Random.State level)
    {
        levelStorage.Add(lvlName, level);
    }

    public void DeleteLevel( string lvlName)
    {
        levelStorage.Remove(lvlName);
    }

    public Random.State LoadLevel(string lvlName)
    {
        return levelStorage[lvlName];
    }
}
