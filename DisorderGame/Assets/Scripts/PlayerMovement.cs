using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D body;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    public float runSpeed = 20;
    public float turnSpeed = 1;

	
	void Start () {

        body = GetComponent<Rigidbody2D>();
        //body.freezeRotation = true;
	}
	
	void Update () {

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        

	}

    void FixedUpdate ()
    {

        Vector2 moveVec = new Vector2(horizontal, vertical) * runSpeed;
        body.AddForce(moveVec);

        if(moveVec != Vector2.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, moveVec), Time.fixedDeltaTime * turnSpeed);
        }

        if(horizontal != 0 && vertical != 0)
        {
            body.velocity = new Vector2((horizontal * runSpeed) * moveLimiter, (vertical * runSpeed) * moveLimiter);
        }
        else
        {
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }

    }
}
