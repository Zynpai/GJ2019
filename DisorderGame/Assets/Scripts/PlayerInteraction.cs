using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    public GameObject InteractionMenu;

	// Use this for initialization
	void Start () {
        InteractionMenu = GameObject.Find("InteractionMenu");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
