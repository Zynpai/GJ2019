using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour {

    int layerMask;
    Rigidbody2D rb2D;

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        layerMask = LayerMask.GetMask("Interactable");
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKeyDown("space"))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1, layerMask);

            if (hit.collider != null)
            {
                // if (hit.collider.tag == "Interactable")
                // {
                Debug.Log("Did Hit" + hit.collider.gameObject.name);
                // }
            }
        }
       
    }
}
