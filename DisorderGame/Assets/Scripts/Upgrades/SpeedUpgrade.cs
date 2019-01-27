using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedUpgrade : MonoBehaviour
{

    string colname;
    public TMP_Text speedText;
    public float fadetime = 100000f;
    public GameObject speed;
    bool speedy;
    TextMeshPro colorText;

    // Use this for initialization
    void Start()
    {
       colorText = GameObject.Find("PowerUp").GetComponent<TextMeshPro>();
        speedy = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (speedy == false)
        {
            colorText.GetComponent<MeshRenderer>().enabled = true;
            StartCoroutine(WaitTime());
            if (col.CompareTag("PlayerTrash"))
        {
            colname = "Trasher";
                col.GetComponent<PlayerMovement1>().runSpeed = col.GetComponent<PlayerMovement1>().runSpeed + 4;
            StartCoroutine(ShowText());
        }
        if (col.CompareTag("PlayerClean"))
        {
            colname = "Cleaner";
            col.GetComponent<PlayerMovement2>().runSpeed = col.GetComponent<PlayerMovement2>().runSpeed + 4;
            StartCoroutine(ShowText());
                Debug.Log("Pick Up");
        }
        speedy = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
        
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(20);
        if (colname == "Cleaner")
        {
            GameObject.Find("PlayerClean").GetComponent<PlayerMovement2>().runSpeed = GameObject.Find("PlayerClean").GetComponent<PlayerMovement2>().runSpeed -4;
        }
        if(colname == "Trasher")
        {
            GameObject.Find("PlayerTrash").GetComponent<PlayerMovement1>().runSpeed = GameObject.Find("PlayerTrash").GetComponent<PlayerMovement1>().runSpeed -4;
        }
    }

    IEnumerator ShowText()
    {
        colorText.color = new Color(colorText.color.r, colorText.color.g, colorText.color.b, 1);
        colorText.GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("PowerUp").transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        speedText = GameObject.Find("PowerUp").GetComponent<TMP_Text>();
        speedText.text = "Speed Boost";
        yield return new WaitForSeconds(1f);
        while(colorText.color.a > 0.0f)
        {
            colorText.color = new Color(colorText.color.r, colorText.color.g, colorText.color.b, colorText.color.a - 0.008f);
            yield return null;
        }
        colorText.GetComponent<MeshRenderer>().enabled = false;
        colorText.color = new Color(colorText.color.r, colorText.color.g, colorText.color.b, 1);
    }
}
