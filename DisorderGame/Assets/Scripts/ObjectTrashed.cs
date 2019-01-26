using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrashed : MonoBehaviour {
    public bool isTrash;
    public bool isClean;
    private SpriteRenderer spriteRenderer;

    private Sprite sprite1;
    private Sprite sprite2;
    public string CleanObj;
    public string TrashObj;

    void Start () {

        spriteRenderer = GetComponent<SpriteRenderer>();
        sprite1 = Resources.Load<Sprite>(CleanObj);
        sprite2 = Resources.Load<Sprite>(TrashObj);
    }
	
	void Update () {
        if (isTrash == true)
        {
            spriteRenderer.sprite = sprite2;          
        }
        if(isClean == true)
        {
            spriteRenderer.sprite = sprite1;
        }
	}
}
