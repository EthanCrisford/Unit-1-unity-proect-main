using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingplatform : MonoBehaviour
{

    public float speed;
    public int startingPoint;
    public Transform[] points; //array of transform points (positions where the platform moves) 

    private int i; //index

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position; 
    }

    // Update is called once per frame
    void Update()
    {

        //checks the distance between the platform and point
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++; //increase index
            if (i == points.Length) //reffers to above if statement, checks the platform index
            {
                i = 0; //reset index 
            }
        }

        //moves the platform the corresponding position based on the index
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
}
