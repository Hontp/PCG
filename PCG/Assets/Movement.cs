using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 5.0f;
    InputManager inputManager;
    UnityInput rawInput;

	// Use this for initialization
	void Start ()
    {
        inputManager = FindObjectOfType<InputManager>();
        rawInput = ScriptableObject.CreateInstance<UnityInput>();

        transform.Translate(Vector3.zero);	
	}
	
	// Update is called once per frame
	void Update ()
    {
        rawInput.QueryControllerInputs();
              
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

        Controller();
    }


    void Controller()
    {

        float horz = rawInput.ControllerAxis.x;                         //Input.GetAxisRaw("J_Horizontal");
        float vert = rawInput.ControllerAxis.y;                         //Input.GetAxisRaw("J_Vertical");

        float dpad_h = rawInput.DpadAxis.x;                      //Input.GetAxisRaw("DPad_Horizontal");
        float dpad_v = rawInput.DpadAxis.y;                         //Input.GetAxisRaw("DPad_Vertical");
    
       Vector3 movement = Vector3.zero;

        if (horz > 0)
        {
            movement += Vector3.right;
        }

        if (horz < 0)
        {
            movement += Vector3.left;
        }
        
        if (vert > 0)
        {
            movement += Vector3.up;
        }

        if ( vert < 0)
        {
            movement += Vector3.down;
        }

        if ( dpad_h > 0)
        {
            movement += Vector3.right;
        }

        if ( dpad_h < 0)
        {
            movement += Vector3.left;
        }

        if (dpad_v > 0)
        {
            movement += Vector3.up;
        }

        if (dpad_v < 0)
        {
            movement += Vector3.down;
        }

        transform.Translate(movement.normalized * speed * Time.deltaTime);
    }
}
