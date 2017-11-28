using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 5.0f;

    List<ControllerScheme> controls;

	// Use this for initialization
	void Start ()
    {
        controls = new List<ControllerScheme>();
        //TODO: detect weather or not to load controller settings, if its plugged in
        controls.Add(ScriptableObject.CreateInstance<Keyboard>());
        controls.Add(ScriptableObject.CreateInstance<Controller>());
	}
	
	// Update is called once per frame
	void Update ()
    {
        for ( int i =0; i < controls.Count; ++i)
        {
            controls[i].UpdateMovement(gameObject, speed);
        }
    }
}
