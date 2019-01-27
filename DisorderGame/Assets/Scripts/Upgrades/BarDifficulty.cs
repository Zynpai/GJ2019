using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BarDifficulty : MonoBehaviour
{


    string colname;
    public TMP_Text diffText;
    public float fadetime = 100f;
    public GameObject speed;
    bool difficult;
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
        if (difficult == false)
        {
            colorText.GetComponent<MeshRenderer>().enabled = true;
            colorText.color = new Color(colorText.color.r, colorText.color.g, colorText.color.b, 1);
            if (col.CompareTag("PlayerTrash"))
            {
                Debug.Log("trash");
                colname = "Trasher";
                GameObject.Find("BarClean").GetComponent<BarMoveClean>().barMult = GameObject.Find("BarClean").GetComponent<BarMoveClean>().barMult * 2.0f;
                GameObject.Find("BarClean").GetComponent<BarMoveClean>().barSpeed = GameObject.Find("BarClean").GetComponent<BarMoveClean>().barSpeed * 2.0f;
                StartCoroutine(ShowText());
            }
            if (col.CompareTag("PlayerClean"))
            {
                colname = "Cleaner";
                GameObject.Find("BarClean").GetComponent<BarMoveClean>().barMult = GameObject.Find("BarClean").GetComponent<BarMoveClean>().barMult / 1.5f;
                GameObject.Find("BarClean").GetComponent<BarMoveClean>().barSpeed = GameObject.Find("BarClean").GetComponent<BarMoveClean>().barSpeed / 1.5f;
                StartCoroutine(ShowText());
            }
            StartCoroutine(WaitTime());
            Debug.Log("started wait");
            difficult = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(20);
        if (colname == "Trasher")
        {
            GameObject.Find("BarClean").GetComponent<BarMoveClean>().barMult = 1.0f;
            Destroy(gameObject);
        }
        if (colname == "Cleaner")
        {
            GameObject.Find("BarClean").GetComponent<BarMoveClean>().barMult = 1.0f;
            Destroy(gameObject);
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
        colorText.GetComponent<MeshRenderer>().enabled = true;
        while (colorText.color.a > 0.0f)
        {
            colorText.color = new Color(colorText.color.r, colorText.color.g, colorText.color.b, colorText.color.a - 0.08f);
            yield return null;
        }
        colorText.GetComponent<MeshRenderer>().enabled = false;

    }
}
