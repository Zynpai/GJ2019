using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreMultiplier : MonoBehaviour {



    string colname;
    public TMP_Text ScoreText;
    public float fadetime = 100f;
    public GameObject speed;
    bool Score;
    TextMeshPro colorText;


    // Use this for initialization
    void Start()
    {
        Score = false;
        TextMeshPro colorText = GameObject.Find("PowerUp").GetComponent<TextMeshPro>();

    }
        // Update is called once per frame
        void Update () {
		
	}


    void OnTriggerEnter2D(Collider2D col)
    {
        if (Score == false)
        {
            if (col.CompareTag("PlayerTrash"))
            {
                Debug.Log("trash");
                colname = "Trasher";
                GameObject.Find("PlayerTrash").GetComponent<TrashInteraction>().Scoremult = 2;
                StartCoroutine(ShowText());
            }
            if (col.CompareTag("PlayerClean"))
            {
                colname = "Cleaner";
                GameObject.Find("PlayerClean").GetComponent<CleanInteraction>().Scoremult = 2;
                StartCoroutine(ShowText());
            }
            StartCoroutine(WaitTime());
            Debug.Log("started wait");
            Score = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(10);
        if (colname == "Cleaner")
        {
            GameObject.Find("PlayerClean").GetComponent<CleanInteraction>().Scoremult = 1;
            Destroy(gameObject);
        }
        if (colname == "Trasher")
        {
            GameObject.Find("PlayerTrash").GetComponent<TrashInteraction>().Scoremult = 1;
            Destroy(gameObject);
        }
    }


    IEnumerator ShowText()
    {
        TextMeshPro colorText = GameObject.Find("PowerUp").GetComponent<TextMeshPro>();
        colorText.color = new Color(colorText.color.r, colorText.color.g, colorText.color.b, 1);
        colorText.GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("PowerUp").transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        ScoreText = GameObject.Find("PowerUp").GetComponent<TMP_Text>();
        ScoreText.text = "Double Score";
        yield return new WaitForSeconds(1f);
        colorText.GetComponent<MeshRenderer>().enabled = true;
        while (colorText.color.a > 0.0f)
        {
            Debug.Log("we here");
            colorText.color = new Color(colorText.color.r, colorText.color.g, colorText.color.b, colorText.color.a - 0.08f);
            yield return null;
        }
        colorText.GetComponent<MeshRenderer>().enabled = false;

    }
}


