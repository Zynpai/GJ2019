using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BarMoveClean : MonoBehaviour {

    Vector3 pointA;
    Vector3 pointB;
    bool cdavailable = false;
    bool finished = false;
    float distance;
    public int ScoreScale;
    public float barSpeed = 10.0f;
    float vol = 1f;
    public AudioClip success;
    AudioSource source;

    void start()
    {
    }

    void OnEnable()
    {

            pointA = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z);
            pointB = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
            transform.position = GameObject.Find("SliderClean").transform.position;
            source = GetComponent<AudioSource>();
    }



    void Update () {
        float time = Mathf.PingPong(Time.time * barSpeed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);

        if(Input.GetKeyDown("enter"))
        {
            finished = false;
            if (cdavailable == true)
            {
                distance = GameObject.Find("SliderClean").transform.position.x - transform.position.x;
                if (distance < 0.3f && distance > -0.3f)
                {
                    ScoreScale = 3;
                    source.PlayOneShot(success, vol);
                }
                else if (distance < 1f && distance > -1f)
                {
                    ScoreScale = 2;
                }
                else
                {
                    ScoreScale = 1;
                }
                GameObject.Find("PlayerClean").GetComponent<CleanInteraction>().SliderDisable();
                cdavailable = false;
                finished = true;
            }

            if (finished == false)
            {
                cdavailable = true;
            }
        }
    }
}   
