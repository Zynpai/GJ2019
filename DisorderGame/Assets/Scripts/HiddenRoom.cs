using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HiddenRoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D()
    {
        Debug.Log("Entered");       
        GameObject.Find("Main Camera").transform.position = new Vector3(9.14f, -5f, -30f);
    }
}
