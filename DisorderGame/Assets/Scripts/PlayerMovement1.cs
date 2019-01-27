using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour {

    Rigidbody2D body;
    float horizontal;
    float vertical;
    float moveLimiter = 0.4f;
    public float runSpeed =
        20;
    public float turnSpeed = 20;
    public bool InGame = false;
    public AudioClip footstep;
    AudioSource source;
    private Vector3 movementVector;
    private CharacterController characterController;


    void Start () {

        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        source = GetComponent<AudioSource>();
        source.clip = footstep;
        source.loop = true;
        source.volume = 1.0f;
    }
	
	void Update () {

    }

    void FixedUpdate ()
    {

        horizontal = Input.GetAxisRaw("LeftJoyStickX");
        vertical = Input.GetAxisRaw("LeftJoyStickY");

        Vector3 pos = transform.position;
        if (InGame == false)
        {
            Vector2 moveVec = new Vector2(horizontal, vertical) * runSpeed;
            body.AddForce(moveVec);
            source.Play();

            if (moveVec != Vector2.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, moveVec), Time.fixedDeltaTime * turnSpeed);
                source.Play();
            }

            if (horizontal != 0 && vertical != 0)
            {
                body.velocity = new Vector2((horizontal * runSpeed) * moveLimiter, (vertical * runSpeed) * moveLimiter);
                source.Play();
            }
            else
            {
                body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
                source.Stop();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Walls")
        {
            Debug.Log("collidedwithwall");
            body.velocity = Vector3.zero;
        }
    }
}
