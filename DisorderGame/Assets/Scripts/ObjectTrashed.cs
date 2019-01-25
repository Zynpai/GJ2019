using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrashed : MonoBehaviour {

    bool isTrash;
    private SpriteRenderer spriteRenderer;

    private Sprite sprite1;
    private Sprite sprite2;

    void Start () {

        spriteRenderer = GetComponent<SpriteRenderer>();

        GameObject player = GameObject.Find("Player");
        Interaction interaction = player.GetComponent<Interaction>();
        bool isTrash = interaction.trashed;
    }
	
	void Update () {
		if(isTrash == true)
        {
            spriteRenderer.sprite = green;
        }
	}
}
