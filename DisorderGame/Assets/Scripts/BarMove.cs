using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMove : MonoBehaviour {

    Vector3 pointA;
    Vector3 pointB;
    public SpriteRenderer sliderRender;

    public float barSpeed = 10.0f;

    void start()
    {
        sliderRender = GameObject.Find("Slider").GetComponent<SpriteRenderer>();
        //pointA = new Vector3(sliderRender.bounds.min.x, transform.position.y, transform.position.z);
        //pointB = new Vector3(sliderRender.bounds.max.x, transform.position.y, transform.position.z);
       // pointA = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
        //pointA = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //this.transform.position = pointA;


    }

    void OnEnable()
    {
        Debug.Log("Enabled");
        pointA = new Vector3(transform.position.x - 0.5f, transform.position.y - 0.5f, transform.position.z - 0.5f);
        pointA = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, transform.position.z + 0.5f);
        transform.position = GameObject.Find("Slider").transform.position;
    }

    void Update () {

        pointA = new Vector3(transform.position.x - 0.1f, transform.position.y - 0.1f, transform.position.z - 0.1f);
        pointA = new Vector3(transform.position.x + 0.1f, transform.position.y + 0.1f, transform.position.z + 0.1f);

         float time = Mathf.PingPong(Time.time * barSpeed, 1);
         transform.position = Vector3.Lerp(pointA, pointB, time);
    }
}   
