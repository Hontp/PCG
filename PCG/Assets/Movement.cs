using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 5.0f;

	// Use this for initialization
	void Start ()
    {
        transform.Translate(Vector3.zero);	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float vertMove = Input.GetAxisRaw("K_Vertical");
        float horizMove = Input.GetAxisRaw("K_Horizontal");

        float Skill1 = Input.GetAxisRaw("Skill1");
        float Skill2 = Input.GetAxisRaw("Skill2");
        float Skill3 = Input.GetAxisRaw("Skill3");
        float Skill4 = Input.GetAxisRaw("Skill4");


        // movement
        transform.Translate(Vector3.right * speed * horizMove * Time.deltaTime);
        transform.Translate(Vector3.up * speed * vertMove *Time.deltaTime);


        // skill keys pressed

        if (Skill1 > 0)
            Debug.Log("use Skill 1");

        if (Skill2 > 0)
            Debug.Log("use Skill 2");

        if (Skill3 > 0)
            Debug.Log("use Skill 3");

        if (Skill4 > 0)
            Debug.Log("use Skill 4");


    }
}
