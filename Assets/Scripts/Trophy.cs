using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trophy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            //Destroy(gameObject);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            Invoke("Endgame", 0.5f);
        }
    }

    void Endgame()
    {
        SceneManager.LoadScene("EndGame");

    }

}
