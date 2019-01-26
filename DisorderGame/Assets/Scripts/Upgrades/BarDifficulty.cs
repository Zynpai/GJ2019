using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NewBehaviourScript : MonoBehaviour
{


    string colname;
    public TMP_Text diffText;
    public float fadetime = 100f;
    public GameObject speed;
    bool difficult;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    void OnTriggerEnter2D(Collider2D col)
    {
        if (difficult == false)
        {
            if (col.CompareTag("PlayerTrash"))
            {
                colname = "Trasher";
                col.GetComponent<BarMoveClean>().barMult = col.GetComponent<BarMoveClean>().barMult * 2.0f;
                StartCoroutine(ShowText());
            }
            if (col.CompareTag("PlayerClean"))
            {
                colname = "Cleaner";
                col.GetComponent<BarMoveClean>().barMult = col.GetComponent<BarMoveClean>().barMult / 1.5f;
                StartCoroutine(ShowText());
            }
            StartCoroutine(WaitTime());
            difficult = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(20);
        if (colname == "Trasher")
        {
            GameObject.Find("PlayerClean").GetComponent<BarMoveClean>().barMult = 1.0f;
        }
        if (colname == "Cleaner")
        {
            GameObject.Find("PlayerClean").GetComponent<BarMoveClean>().barMult = 1.0f;
        }
    }


    IEnumerator ShowText()
    {
        GameObject.Find("PowerUp").transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        diffText = GameObject.Find("PowerUp").GetComponent<TMP_Text>();
        diffText.text = "Bar Difficulty";
        Debug.Log("before coroutine");
        yield return new WaitForSeconds(1f);
        Debug.Log("after coroutine");
        TextMeshPro colorText = GameObject.Find("PowerUp").GetComponent<TextMeshPro>();
        colorText.color = new Color(colorText.color.r, colorText.color.g, colorText.color.b, 1);
        Debug.Log(colorText.color);
        while (colorText.color.a > 0.0f)
        {
            Debug.Log("we here");
            colorText.color = new Color(colorText.color.r, colorText.color.g, colorText.color.b, colorText.color.a - (Time.deltaTime / fadetime));
            yield return null;
        }

    }
}
