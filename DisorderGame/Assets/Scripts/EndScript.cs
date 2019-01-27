using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScript : MonoBehaviour {


    float percent;
    bool trasher;
    public Text EndText;
    // Use this for initialization
    void Start () {

        percent = TimerController.percent * 100f;
        Debug.Log(percent);
        trasher = TimerController.trasher;
        decimal Dec = (decimal)percent;
        Debug.Log(Dec);
        Dec = Math.Round(Dec, 2);
        if (trasher)
        {
            EndText.text = Dec.ToString() + "% Room Trashed at end!";
        }
        else
        {
            EndText.text = Dec.ToString() + "% Room Cleaned at end!";
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
