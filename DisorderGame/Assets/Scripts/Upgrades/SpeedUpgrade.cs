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
            col.GetComponent<PlayerMovement1>().runSpeed = col.GetComponent<PlayerMovement1>().runSpeed * 2;
            StartCoroutine(ShowText());
        }
        if (col.CompareTag("PlayerClean"))
        {
            colname = "Cleaner";
            col.GetComponent<PlayerMovement2>().runSpeed = col.GetComponent<PlayerMovement2>().runSpeed * 2;
            StartCoroutine(ShowText());
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
            GameObject.Find("PlayerClean").GetComponent<PlayerMovement2>().runSpeed = GameObject.Find("PlayerClean").GetComponent<PlayerMovement2>().runSpeed / 2;
        }
        if(colname == "Trasher")
        {
            GameObject.Find("PlayerTrash").GetComponent<PlayerMovement1>().runSpeed = GameObject.Find("PlayerTrash").GetComponent<PlayerMovement1>().runSpeed / 2;
        }
    }

    IEnumerator ShowText()
    {
        GameObject.Find("PowerUp").transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        speedText = GameObject.Find("PowerUp").GetComponent<TMP_Text>();
        speedText.text = "Speed Boost2";
        Debug.Log("before coroutine");
        yield return new WaitForSeconds(1f);
        Debug.Log("after coroutine");
        TextMeshPro colorText = GameObject.Find("PowerUp").GetComponent<TextMeshPro>();
        colorText.color = new Color(colorText.color.r, colorText.color.g, colorText.color.b, 1);
        Debug.Log(colorText.color);
        while(colorText.color.a > 0.0f)
        {
            Debug.Log("we here");
            colorText.color = new Color(colorText.color.r, colorText.color.g, colorText.color.b, colorText.color.a - 0.008f);
            yield return null;
        }
        colorText.GetComponent<MeshRenderer>().enabled = false;
        colorText.color = new Color(colorText.color.r, colorText.color.g, colorText.color.b, 1);
    }
}
