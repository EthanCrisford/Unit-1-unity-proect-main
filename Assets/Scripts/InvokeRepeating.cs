using UnityEngine;

public class InvokeRepeating : MonoBehaviour
{
    public GameObject LargeGreen; 

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", 2, 4);
    }

    void SpawnObject()
    {
        float x = transform.position.x; 
        float y = transform.position.y;
        float z = transform.position.z;
        Instantiate(LargeGreen, new Vector2(x, y), Quaternion.identity);
    }
}
