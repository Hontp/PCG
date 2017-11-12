using UnityEngine;
using System.Collections;

public class DebugRand : MonoBehaviour {

    public Level lvlDB;

	// Use this for initialization
	void Start () {

        Random.InitState(0);

        PrintLog("initRandomState");

        lvlDB.SaveLevel("test1", Random.state);

        PrintLog("State 2");

        Random.state = lvlDB.LoadLevel("test1");

        PrintLog("State 3");
	}

    void PrintLog(string debug)
    {
        Debug.Log(string.Format(debug + ": {1}", debug ,Random.Range(0, 100)));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
