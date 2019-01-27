using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TheSnap : MonoBehaviour {


    string colname;
    public TMP_Text ScoreText;
    int Decider = 0;
    int count = 0;
    public float fadetime = 100f;
    GameObject[] List = new GameObject[50];
    GameObject[] FilteredList = new GameObject[50];

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        StartCoroutine(ShowText());
        if (col.CompareTag("PlayerTrash"))
        {
            Debug.Log("trash");
            List = GameObject.FindGameObjectsWithTag("Object");
            Debug.Log("before first foreach");
            count = 0;
            foreach (GameObject g in List)
            {
                if (g.GetComponent<ObjectTrashed>().isTrash == true)
                { 
                    FilteredList[count] = g;
                    count = count + 1;
                }
            }
            Debug.Log("before second foreach");
            foreach (GameObject g in FilteredList)
            {
                Decider = Random.Range(1, 3);
                if (Decider == 1)
                {
                    Debug.Log("snapping something....?");
                    g.GetComponent<ObjectTrashed>().isClean = true;
                    g.GetComponent<ObjectTrashed>().isTrash = false;
                }
            }
        }
        if (col.CompareTag("PlayerClean"))
        {
            List = GameObject.FindGameObjectsWithTag("Object");
            count = 0;
            foreach (GameObject g in List)
            {
                if (g.GetComponent<ObjectTrashed>().isTrash == false)
                {
                    FilteredList[count] = g;
                    count = count + 1;
                }
            }
            foreach (GameObject g in FilteredList)
            {
               Decider =  Random.Range(1, 4);
                if (Decider == 1)
                {
                    g.GetComponent<ObjectTrashed>().isClean = false;
                    g.GetComponent<ObjectTrashed>().isTrash = true;
                }
            }

        }
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        
    }



    IEnumerator ShowText()
    {
        Debug.Log("show text");
        GameObject.Find("PowerUp").transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        ScoreText = GameObject.Find("PowerUp").GetComponent<TMP_Text>();
        ScoreText.text = "Equalised, as all things could be";
        Debug.Log("before coroutine");
        yield return new WaitForSeconds(1f);
        Debug.Log("after coroutine");
        TextMeshPro colorText = GameObject.Find("PowerUp").GetComponent<TextMeshPro>();
        colorText.GetComponent<MeshRenderer>().enabled = true;
        colorText.color = new Color(colorText.color.r, colorText.color.g, colorText.color.b, 1);
        Debug.Log(colorText.color);
        while (colorText.color.a > 0.0f)
        {
            Debug.Log("we here");
            colorText.color = new Color(colorText.color.r, colorText.color.g, colorText.color.b, colorText.color.a - 0.08f);
            yield return null;
        }
        Destroy(gameObject);
    }
}
