using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winscreen : MonoBehaviour {
    
    private SpriteRenderer spriteRenderer;

    private Sprite sprite1;
    private Sprite sprite2;
    public string CleanObj;
    public string TrashObj;
    int cleanerscore = CleanInteraction.Score;
    int trasherscore = TrashInteraction.Score;
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        sprite1 = Resources.Load<Sprite>(CleanObj);
        sprite2 = Resources.Load<Sprite>(TrashObj);
    }

    void Update()
    {
        
        if (cleanerscore>trasherscore)
        {
            spriteRenderer.sprite = sprite1;
        }else
        {
            spriteRenderer.sprite = sprite2;
        }
    }
}

