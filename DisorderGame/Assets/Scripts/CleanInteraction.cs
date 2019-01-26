using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CleanInteraction : MonoBehaviour
{

    int layerMask;
    public SpriteRenderer sliderCleanRender;
    public SpriteRenderer barCleanRender;
    string hitname;

    [SerializeField] private BarMoveClean barClean;

    // Use this for initialization
    void Start()
    {
       
        layerMask = LayerMask.GetMask("Interactable");
        sliderCleanRender = GameObject.Find("SliderClean").GetComponent<SpriteRenderer>();
        barCleanRender = GameObject.Find("BarClean").GetComponent<SpriteRenderer>();
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
                Debug.Log("hit");
                hitname = hit.collider.gameObject.name;
            }
        }

    }

    void SliderEnable()
    {
        GameObject.Find("SliderClean").transform.position = transform.position;
        GameObject.Find("BarClean").transform.position = transform.position;
        barCleanRender.enabled = true;
        sliderCleanRender.enabled = true;
        this.GetComponent<PlayerMovement2>().InGame = true;
        barClean.enabled = true;
        Debug.Log("enable slider");
    }

    public void SliderDisable()
    {
        barCleanRender.enabled = false;
        sliderCleanRender.enabled = false;
        GameObject.Find("PlayerClean").GetComponent<PlayerMovement2>().InGame = false;
        barClean.enabled = false;
        GameObject.Find(hitname).GetComponent<ObjectTrashed>().isClean = true;
        GameObject.Find(hitname).GetComponent<ObjectTrashed>().isTrash = false;
        Debug.Log("disable slider");
    }
}
