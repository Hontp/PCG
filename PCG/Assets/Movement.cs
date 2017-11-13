using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 5.0f;
    InputManager inputManager;

	// Use this for initialization
	void Start ()
    {
        inputManager = FindObjectOfType<InputManager>();

        transform.Translate(Vector3.zero);	
	}
	
	// Update is called once per frame
	void Update ()
    {       
        Vector3 movement = Vector3.zero;
        
        if (inputManager.GetButtonDown("Up"))
        {
            movement += Vector3.up;
        }

        if ( inputManager.GetButtonDown("Left"))
        {
            movement += Vector3.left;
        }

        if (inputManager.GetButtonDown("Right"))
        {

            movement += Vector3.right;
        }

        if (inputManager.GetButtonDown("Down"))
        {
            movement += Vector3.down;
        }

        transform.Translate(movement.normalized * speed * Time.deltaTime);

    }
}
