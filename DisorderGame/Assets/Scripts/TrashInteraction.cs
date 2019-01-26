using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrashInteraction : MonoBehaviour {

    int layerMask;
    public SpriteRenderer sliderTrashRender;
    public SpriteRenderer barTrashRender;
    string hitname;

    [SerializeField] private BarMoveTrash barTrash;
    // Use this for initialization
    void Start () {
        layerMask = LayerMask.GetMask("Interactable");
        sliderTrashRender = GameObject.Find("SliderTrash").GetComponent<SpriteRenderer>();
        barTrashRender = GameObject.Find("BarTrash").GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKeyDown("space"))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1, layerMask);

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ObjectTrashed>().isTrash == false)
                {
                    SliderEnable();
                    hitname = hit.collider.gameObject.name;
                }
            }
        }
       
    }

    void SliderEnable()
    {
        GameObject.Find("SliderTrash").transform.position = transform.position;
        GameObject.Find("BarTrash").transform.position = transform.position;
        barTrashRender.enabled = true;
        sliderTrashRender.enabled = true;
        this.GetComponent<PlayerMovement1>().InGame = true;
        barTrash.enabled = true;
        Debug.Log("enable slider");
    }

    public void SliderDisable()
    {
        barTrashRender.enabled = false;
        sliderTrashRender.enabled = false;
        GameObject.Find("PlayerTrash").GetComponent<PlayerMovement1>().InGame = false;
        barTrash.enabled = false;
        GameObject.Find(hitname).GetComponent<ObjectTrashed>().isClean = false;
        GameObject.Find(hitname).GetComponent<ObjectTrashed>().isTrash = true;
        Debug.Log("disable slider");
    }
}
