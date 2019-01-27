using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPower : MonoBehaviour {

    public GameObject Speed;
    public GameObject Points;
    public GameObject Bar;
    public GameObject Snap;

    Vector3[] positionArray = new[]
    {
         new Vector3(1.93f, 9.09f, 0.0f),
         new Vector3(-0.4f, 7.23f, 0.0f),
         new Vector3(5.46f, 9.41f, 0.0f),
         new Vector3(6.32f, 7.14f, 0.0f),
         new Vector3(3.72f, 7.29f, 0.0f),
         new Vector3(-0.11f, 4.96f, 0.0f),
         new Vector3(5.08f, 5.02f, 0.0f),
         new Vector3(8.97f, 4.93f, 0.0f),
         new Vector3(12.15f, 6.79f, 0.0f),
         new Vector3(0.16f, 0.99f, 0.0f),
         new Vector3(1.34f, 3.08f, 0.0f),
         new Vector3(6.11f, 0.81f, 0.0f),
         new Vector3(8.97f, 1.9f, 0.0f),
         new Vector3(17.21f, 5.11f, 0.0f),
         new Vector3(12.83f, 4.99f, 0.0f),
         new Vector3(8.88f, 7.7f, 0.0f),
         new Vector3(3.2f, 1.11f, 0.0f),
         new Vector3(13.03f, 1.9f, 0.0f),
         new Vector3(14.27f, 3.14f, 0.0f),
         new Vector3(12.47f, 9.14f, 0.0f),
         new Vector3(17.63f, 6.88f, 0.0f),
         new Vector3(17.69f, 9.05f, 0.0f),
         new Vector3(18.28f, 2.52f, 0.0f),
         new Vector3(17.19f, 0.78f, 0.0f),
         new Vector3(16.04f, 2.61f, 0.0f),
};

    string[] powerArray = 
    {
        "Speed",
       "Points",
       "Bar",
       "Snap",

    };
   


	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnStuff());
	}
	
	// Update is called once per frame
	void Update () {
		


	}
    
    IEnumerator SpawnStuff()
    {
        float ranNum = Random.Range(1, 5);
        yield return new WaitForSeconds(ranNum);
        Debug.Log("Before Spawn");
        SpawnRandom();
    }

    void SpawnRandom()
    {
        Debug.Log("On Spawn");
        int ranPos = Random.Range(0, 25);
        string ranPow = powerArray[Random.Range(0, 4)];
        if(ranPow == "Speed")
        {
            Instantiate(Speed, positionArray[ranPos], Quaternion.identity);
        }
        else if(ranPow == "Points")
        {
            Instantiate(Points, positionArray[ranPos], Quaternion.identity);
        }
        else if (ranPow == "Bar")
        {
            Instantiate(Bar, positionArray[ranPos], Quaternion.identity);
        }
        else if(ranPow == "Snap")
        {
            Instantiate(Snap, positionArray[ranPos], Quaternion.identity);
        }

        StartCoroutine(SpawnStuff());
    }
}
