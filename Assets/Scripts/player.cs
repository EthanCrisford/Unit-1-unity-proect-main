using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    bool touchingPlatform = false;
    private Animator anim;
    bool idle;
    bool isJumping;
    bool Jump;
    bool walk;
    bool isWalking; 
    HelperScript helper;
    public GameObject bullet; // prefab

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        isJumping = false;

        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetBool("walk", false);
        anim.SetBool("jump", false);
        anim.SetBool("idle", false);

        if (isJumping == false && (walk = false) && (touchingPlatform == true)) 
        {
            anim.SetBool("idle", true);
        }

        // check for player landing
        if (isJumping && (touchingPlatform == true) && (rb.velocity.y < 0) && (isWalking == false)) 
        {
            isJumping = false; 
            anim.SetBool("idle", true);
        }

        if (Input.GetKey("space") && (touchingPlatform == true))
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));
            rb.velocity = new Vector2(0, 9); 
            anim.SetBool("jump", true);
            isJumping = true;
        }

        // player stopped walking check
        if (isWalking == false && (touchingPlatform == true) && (rb.velocity.x < 0)) 
        {
            anim.SetBool("idle", true);
            isWalking = false; 
        }


        if (Input.GetKey("s"))
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y - (speed * Time.deltaTime));
            //player1.velocity = new Vector2(0, -4);
            //anim.SetBool("walk", true);
            //anim.SetBool("idle", false);
        }

        if( Input.GetMouseButtonDown (0))
        {
            Rigidbody2D rb;
            GameObject obj = Instantiate(bullet, transform.position, transform.rotation);

            rb = obj.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(10,0);
            if (Input.GetKey("a"))
                rb.velocity = new Vector2(-10,0);
            
        }


        if (Input.GetKey("a"))
        {
            //transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            rb.velocity = new Vector2(-5, 0);
            anim.SetBool("walk", true);
            anim.SetBool("idle", false);
            helper.FlipObject(true);
        }


        if (Input.GetKey("d"))
        {
            //transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            rb.velocity = new Vector2(5, 0);
            anim.SetBool("walk", true);
            anim.SetBool("idle", false);
            helper.FlipObject(false);
        }

        if (isJumping == true)
        {
            anim.SetBool("jump", true);
        }

        bool groundHit = helper.DoRayCollisionCheck();
        if (groundHit == true)
        {
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "platform")
        {
            touchingPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "platform")
        {
            touchingPlatform = false;
        }
    }
} 

