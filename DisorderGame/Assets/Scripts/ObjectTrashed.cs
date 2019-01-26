using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrashed : MonoBehaviour {
    public bool isTrash;
    public bool isClean;
    private SpriteRenderer spriteRenderer;

    private Sprite sprite1;
    private Sprite sprite2;

    void Start () {

        spriteRenderer = GetComponent<SpriteRenderer>();
        sprite1 = Resources.Load<Sprite>("green");
        sprite2 = Resources.Load<Sprite>("blue");
    }
	
	void Update () {
        if (isTrash == true)
        {
            spriteRenderer.sprite = sprite1;          
        }
        if(isClean == true)
        {
            spriteRenderer.sprite = sprite2;
        }
	}
}
