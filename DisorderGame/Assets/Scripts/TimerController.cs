using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour {

    public Text TimerText;
    public static int min;
    public static int sec;
    public static float percent;
    public static bool trasher;
    // Use this for initialization
    void Start () {
        TextUpdate();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.frameCount%60 == 0)
        {
            if (sec == 0 && min == 0)
            {
                percent = CalcPercent();
                Time.timeScale = 0;
                SceneManager.LoadScene("EndScreen");
            }
            else if (sec == 0)
            {
                sec = 59;
                min = min - 1;
                TextUpdate();
            }
            else
            {
                sec = sec - 1;
                TextUpdate();
            }
        }
        
	}

    void TextUpdate()
    {
        if (sec < 10)
        {
            TimerText.text = min + ":0" + sec;
            if (min == 0)
            {
                GameObject easter = GameObject.Find("Easter");
                Destroy(easter);
            
            }
        }
        else
        {
            TimerText.text = min + ":" + sec;
        }
    }


    float CalcPercent()
    {
        GameObject[] List = new GameObject[50];
        float trash = 0.0f;
        float clean = 0.0f;
        
        List = GameObject.FindGameObjectsWithTag("Object");
        foreach (GameObject g in List)
        {
            if (g.GetComponent<ObjectTrashed>().isTrash == true)
            {
                trash = trash + 1.0f;
                Debug.Log(trash);
            }
            else
            {
                clean = clean + 1.0f;
                Debug.Log(clean);
            }

        }
        if (clean > trash)
        {
            
            percent = clean / List.Length;
            trasher = false;
        }
        else
        {
            percent = trash / List.Length;
            trasher = true;
        }
        Debug.Log(percent);
        return percent;
        
    
    }


}
