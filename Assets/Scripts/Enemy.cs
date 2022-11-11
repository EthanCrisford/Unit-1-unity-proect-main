using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    LayerMask groundLayerMask;
    float playerx, playery;
    float enemyx, enemyy;
    public GameObject player;
    Rigidbody2D enemyRigidBody2D;
    public int UnitsToMove = 5;
    public float EnemySpeed = 25;
    public bool _isFacingRight;
    public Rigidbody2D rb;
    //public int lifeTotal = 3;

    public bool DoRayCollisionCheck( float xoffs )
    {

        float rayLength = 1.0f;

        Vector3 position = transform.position;
        position.x += xoffs;


        //cast a ray downwards of length 1
        RaycastHit2D hit = Physics2D.Raycast(position, -Vector2.up, rayLength, groundLayerMask);

        if (hit.collider == null)
        {
            Debug.DrawRay(position, -Vector2.up * rayLength, Color.black);

            return false;
        }
        Debug.DrawRay(position, -Vector2.up * rayLength, Color.red);

        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        groundLayerMask = LayerMask.GetMask("ground");

        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isHittingPlatform;

        isHittingPlatform = DoRayCollisionCheck(0.3f);
        isHittingPlatform = DoRayCollisionCheck((float)-0.3);

        //print("is hitting=" + isHittingPlatform);

        playerx = player.transform.position.x;
        playery = player.transform.position.y;

        enemyx = transform.position.x;
       // if (playerx < enemyx)
            //print("player is on the left");
        //else print("player is on the right");

        rb.velocity = transform.right * EnemySpeed; 


    }

    public void Flip()
    {
        //transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        //_isFacingRight = transform.localScale.x > 0;
    }
}
