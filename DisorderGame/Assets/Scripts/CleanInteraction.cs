using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CleanInteraction : MonoBehaviour
{

    int layerMask;
    public SpriteRenderer sliderCleanRender;
    public SpriteRenderer barCleanRender;
    string hitname;
    int Scorescale;
    public int Scoremult = 1;
    private int Score;
    public Text Cleanertext;
    [SerializeField] private BarMoveClean barClean;

    // Use this for initialization
    void Start()
    {
       
        layerMask = LayerMask.GetMask("Interactable");
        sliderCleanRender = GameObject.Find("SliderClean").GetComponent<SpriteRenderer>();
        barCleanRender = GameObject.Find("BarClean").GetComponent<SpriteRenderer>();
        Score = 0;
        Textupdate();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1, layerMask);

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ObjectTrashed>().isTrash == true)
                {
                    SliderEnable();
                    hitname = hit.collider.gameObject.name;
                }
            }
        }

    }

    void SliderEnable()
    {
        GameObject.Find("SliderClean").transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        GameObject.Find("BarClean").transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        barCleanRender.enabled = true;
        sliderCleanRender.enabled = true;
        this.GetComponent<PlayerMovement2>().InGame = true;
        barClean.enabled = true;
    }

    public void SliderDisable()
    {
        barCleanRender.enabled = false;
        sliderCleanRender.enabled = false;
        GameObject.Find("PlayerClean").GetComponent<PlayerMovement2>().InGame = false;
        barClean.enabled = false;
        GameObject.Find(hitname).GetComponent<ObjectTrashed>().isClean = true;
        GameObject.Find(hitname).GetComponent<ObjectTrashed>().isTrash = false;
        Scorescale = GameObject.Find("BarClean").GetComponent<BarMoveClean>().ScoreScale;
        Score = Score + (Scorescale * Scoremult);
        Textupdate();
    }
    void Textupdate()
    {
        Cleanertext.text = "Cleaner Score: " + Score.ToString();
    }
}
