
using UnityEngine;

public class Controller : ControllerScheme
{
    InputManager manager;

    void OnEnable()
    {
        manager = FindObjectOfType<InputManager>();

        Debug.Log("Controller controls Loaded");
    }


    public override void UpdateMovement(GameObject obj, float speed)
    {
        Vector3 movement = manager.GetThumbStickDirection();

        if (manager.GetThumbStickDirection() == Vector3.right)
        {
            movement += manager.GetThumbStickDirection();
        }

        if (manager.GetThumbStickDirection() == Vector3.left)
        {
            movement += manager.GetThumbStickDirection();
        }

        if (manager.GetThumbStickDirection() == Vector3.up)
        {
            movement += manager.GetThumbStickDirection();
        }

        if (manager.GetThumbStickDirection() == Vector3.down)
        {
            movement += manager.GetThumbStickDirection();
        }

        obj.transform.Translate(movement.normalized * speed * Time.deltaTime);
    }

}
