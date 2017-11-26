using UnityEngine;

public class UnityInput :ScriptableObject
{
    // Left thumbstick
    Vector2 joyAxis;
    Vector2 dpadAxis;

    // A,B,X,Y buttons
    Vector4 joyButtons;

    //Bumpers
    Vector2 joyBumpers;

    // Triggers
    //NOTE: The left trigger is represented by the range -1 to 0, 
    //while the right trigger is represented by the range 0 to 1. 
    float joyTriggers;

    void OnEnable()
    {
        QueryControllerInputs();
    }

    public Vector2 ControllerAxis
    {
        get
        {
            return joyAxis;
        }
    }

    public Vector2 DpadAxis
    {
        get
        {
            return dpadAxis;
        }
    }

    public Vector4 FaceButtons
    {
        get
        {
            return joyButtons;
        }
    }

    public Vector2 Bumpers
    {
        get
        {
            return joyBumpers;
        }
    }

    public float Triggers
    {
        get
        {
            return joyTriggers;
        }
    }

    public void QueryControllerInputs()
    {
        joyAxis.x = Input.GetAxisRaw("J_Horizontal");
        joyAxis.y = Input.GetAxisRaw("J_Vertical");

        dpadAxis.x = Input.GetAxisRaw("DPad_Horizontal");
        dpadAxis.y = Input.GetAxisRaw("DPad_Vertical");

        joyButtons.x = Input.GetAxisRaw("ButtonA");
        joyButtons.y = Input.GetAxisRaw("ButtonB");
        joyButtons.z = Input.GetAxisRaw("ButtonX");
        joyButtons.w = Input.GetAxisRaw("ButtonY");

        joyBumpers.x = Input.GetAxisRaw("LeftBumper");
        joyBumpers.y = Input.GetAxisRaw("RightBumper");

        joyTriggers = Input.GetAxisRaw("Triggers");
    }
    
    

}
