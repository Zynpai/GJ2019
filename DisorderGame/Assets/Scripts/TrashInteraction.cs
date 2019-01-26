using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrashInteraction : MonoBehaviour {

    int layerMask;
    public bool trashed;

    // Use this for initialization
    void Start () {
        layerMask = LayerMask.GetMask("Interactable");
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKeyDown("space"))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1, layerMask);

            if (hit.collider != null)
            {
                hit.collider.GetComponent<ObjectTrashed>().isTrash = true;
                hit.collider.GetComponent<ObjectTrashed>().isClean = false;
            }
        }
       
    }
}
