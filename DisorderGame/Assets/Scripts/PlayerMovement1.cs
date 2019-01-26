using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour {

    Rigidbody2D body;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    public float runSpeed = 20;
    public float turnSpeed = 20;
    public bool InGame = false;
	
	void Start () {

        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;

    }
	
	void Update () {

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Vector3 pos = transform.position;

    }

    void FixedUpdate ()
    {
        //transform.rotation = Quaternion.identity;
        if (InGame == false && !Input.GetKeyDown("a") && !Input.GetKeyDown("w") && !Input.GetKeyDown("s") && !Input.GetKeyDown("d"))
        {
            Vector2 moveVec = new Vector2(horizontal, vertical) * runSpeed;
            body.AddForce(moveVec);

            if (moveVec != Vector2.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, moveVec), Time.fixedDeltaTime * turnSpeed);
            }

            if (horizontal != 0 && vertical != 0)
            {
                body.velocity = new Vector2((horizontal * runSpeed) * moveLimiter, (vertical * runSpeed) * moveLimiter);
            }
            else
            {
                body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
            }
        }
    }
}
