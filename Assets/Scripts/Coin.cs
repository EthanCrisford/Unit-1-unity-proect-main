using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("coin has started");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        print("collision with " + col.gameObject.name);
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
