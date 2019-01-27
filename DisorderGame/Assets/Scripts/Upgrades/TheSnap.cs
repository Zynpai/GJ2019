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
    public GameObject[] List;
    public GameObject[] FilteredList;
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
                int Decider = Random.Range(0, 3);
                if (Decider == 1)
                {
                    Debug.Log("snapping something....?");
                    g.GetComponent<ObjectTrashed>().isClean = true;
                    g.GetComponent<ObjectTrashed>().isTrash = false;
                    listcounter += 1;
                }
                if(Mathf.Floor(listcounter/3) >= FilteredList.Length)
                {
                    break;
                }
            }
        }
        if (col.CompareTag("PlayerClean"))
        {
            Debug.Log("CleanSnap");
            List = GameObject.FindGameObjectsWithTag("Object");
            count = 0;
            listcounter = 0;
            foreach (GameObject g in List)
            {
                if (g.layer == 8)
                {
                    FilteredList[count] = g;
                    count += 1;
                    Debug.Log(count);
                }
            }
            foreach (GameObject g in FilteredList)
            {
               Decider =  Random.Range(0, 3);
                if (Decider == 1)
                {
                    try
                    {
                        g.GetComponent<ObjectTrashed>().isClean = false;
                        g.GetComponent<ObjectTrashed>().isTrash = true;
                        listcounter += 1;
                    }
                    catch { }
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
