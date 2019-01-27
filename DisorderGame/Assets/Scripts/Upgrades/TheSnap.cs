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
    int listcounter = 0;
    public float fadetime = 100f;
    GameObject[] List = new GameObject[50];
    GameObject[] FilteredList = new GameObject[50];
    TextMeshPro colorText;

    // Use this for initialization
    void Start () {
        TextMeshPro colorText = GameObject.Find("PowerUp").GetComponent<TextMeshPro>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        StartCoroutine(ShowText());
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        if (col.CompareTag("PlayerTrash"))
        {
            Debug.Log("trash");
            List = GameObject.FindGameObjectsWithTag("Object");
            Debug.Log("before first foreach");
            count = 0;
            listcounter = 0;
            foreach (GameObject g in List)
            {
                if (g.GetComponent<ObjectTrashed>().isTrash == true)
                { 
                    FilteredList[count] = g;
                    count += 1;
                }
            }
            Debug.Log("before second foreach");
            foreach (GameObject g in FilteredList)
            {
                int Decider = Random.Range(1, 4);
                if (Decider == 1)
                {
                    Debug.Log("snapping something....?");
                    g.GetComponent<ObjectTrashed>().isClean = true;
                    g.GetComponent<ObjectTrashed>().isTrash = false;
                    listcounter += 1;
                }
                if(Mathf.Round(listcounter/2) >= FilteredList.Length)
                {
                    break;
                }
            }
        }
        if (col.CompareTag("PlayerClean"))
        {
            List = GameObject.FindGameObjectsWithTag("Object");
            count = 0;
            listcounter = 0;
            foreach (GameObject g in List)
            {
                if (g.GetComponent<ObjectTrashed>().isTrash == false)
                {
                    FilteredList[count] = g;
                    count += 1;
                }
            }
            foreach (GameObject g in FilteredList)
            {
               Decider =  Random.Range(1, 4);
                if (Decider == 1)
                {
                    g.GetComponent<ObjectTrashed>().isClean = false;
                    g.GetComponent<ObjectTrashed>().isTrash = true;
                    listcounter += 1;
                }
                if (Mathf.Round(listcounter / 2) >= FilteredList.Length)
                {
                    break;
                }
            }

        }
        
    }



    IEnumerator ShowText()
    {
        TextMeshPro colorText = GameObject.Find("PowerUp").GetComponent<TextMeshPro>();
        colorText.color = new Color(colorText.color.r, colorText.color.g, colorText.color.b, 1);
        colorText.GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("PowerUp").transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        ScoreText = GameObject.Find("PowerUp").GetComponent<TMP_Text>();
        ScoreText.text = "Equalised, as all things could be";
        yield return new WaitForSeconds(1f);
        colorText.GetComponent<MeshRenderer>().enabled = true;
        while (colorText.color.a > 0.0f)
        {
            Debug.Log("we here");
            colorText.color = new Color(colorText.color.r, colorText.color.g, colorText.color.b, colorText.color.a - 0.08f);
            yield return null;
        }
        colorText.GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject);

    }
}
