﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TrashInteraction : MonoBehaviour {

    int layerMask;
    public SpriteRenderer sliderTrashRender;
    public SpriteRenderer barTrashRender;
    string hitname;
    int Scorescale;
    public int Scoremult = 1;
    private int Score;
    public Text Trashscore;
    
    [SerializeField] private BarMoveTrash barTrash;
    // Use this for initialization
    void Start () {
        layerMask = LayerMask.GetMask("Interactable");
        sliderTrashRender = GameObject.Find("SliderTrash").GetComponent<SpriteRenderer>();
        barTrashRender = GameObject.Find("BarTrash").GetComponent<SpriteRenderer>();
        Score = 0;
        Textupdate();

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
        GameObject.Find("SliderTrash").transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        GameObject.Find("BarTrash").transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        barTrashRender.enabled = true;
        sliderTrashRender.enabled = true;
        this.GetComponent<PlayerMovement1>().InGame = true;
        barTrash.enabled = true;
    }

    public void SliderDisable()
    {
        barTrashRender.enabled = false;
        sliderTrashRender.enabled = false;
        GameObject.Find("PlayerTrash").GetComponent<PlayerMovement1>().InGame = false;
        barTrash.enabled = false;
        GameObject.Find(hitname).GetComponent<ObjectTrashed>().isClean = false;
        GameObject.Find(hitname).GetComponent<ObjectTrashed>().isTrash = true;
        Scorescale = GameObject.Find("BarTrash").GetComponent<BarMoveTrash>().ScoreScale;
        Score = Score + (Scorescale * Scoremult);
        Textupdate();
    }


    void Textupdate()
    {
        Trashscore.text = "Trasher Score: " + Score.ToString();
    }
}
