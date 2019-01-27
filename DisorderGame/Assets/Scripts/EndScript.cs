using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScript : MonoBehaviour {


    float percent;
    bool trasher;
    public Text EndText;
    // Use this for initialization
    void Start () {

        percent = TimerController.percent;
        trasher = TimerController.trasher;
        if (trasher)
        {
            EndText.text = (percent * 100) + "% Room Trashed at end!";
        }
        else
        {
            EndText.text = (percent * 100) + "% Room Cleaned at end!";
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
