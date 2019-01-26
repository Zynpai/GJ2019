using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CleanInteraction : MonoBehaviour
{

    int layerMask;
    public SpriteRenderer sliderRender;
    public SpriteRenderer barRender;
    public Transform slider;
    public Transform bar;

    // Use this for initialization
    void Start()
    {
        layerMask = LayerMask.GetMask("Interactable");
        sliderRender = GameObject.Find("Slider").GetComponent<SpriteRenderer>();
        barRender = GameObject.Find("Bar").GetComponent<SpriteRenderer>();
        slider = this.gameObject.transform.GetChild(0);
        bar = this.gameObject.transform.GetChild(1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKeyDown("enter"))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1, layerMask);

            if (hit.collider != null)
            {
                SliderEnable();
                hit.collider.GetComponent<ObjectTrashed>().isClean = true;
                hit.collider.GetComponent<ObjectTrashed>().isTrash = false;
            }
        }

    }

    void SliderEnable()
    {
        slider.transform.position = transform.position;
        //bar.transform.position = transform.position;
        barRender.enabled = true;
        sliderRender.enabled = true;
        this.GetComponent<PlayerMovement2>().InGame = true;
        GetComponentInChildren<BarMove>().enabled = true;
    }
}
