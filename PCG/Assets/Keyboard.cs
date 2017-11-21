using UnityEngine;

public class Keyboard : ControllerScheme
{
    InputManager manager;
   
    void OnEnable()
    {
        manager = FindObjectOfType<InputManager>();

        Debug.Log("Keyboard controls Loaded");
    }

    public override void UpdateMovement(GameObject obj, float speed)
    {
        Vector3 movement = Vector3.zero;

        if (manager.GetButtonDown("Up"))
        {
            movement += Vector3.up;
        }

        if (manager.GetButtonDown("Left"))
        {
            movement += Vector3.left;
        }

        if (manager.GetButtonDown("Right"))
        {

            movement += Vector3.right;
        }

        if (manager.GetButtonDown("Down"))
        {
            movement += Vector3.down;
        }

        obj.transform.Translate(movement.normalized * speed * Time.deltaTime);
    }
}
