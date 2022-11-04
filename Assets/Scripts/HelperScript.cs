using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using System.Runtime.InteropServices;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UIElements;

public class HelperScript : MonoBehaviour
{
    float distance;
    int groundLayer;

    LayerMask groundLayerMask;
    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false; 
    }
    
    void Start()
    {
        groundLayerMask = LayerMask.GetMask("ground");
    }

    public bool DoRayCollisionCheck()
    {
        float rayLength = 1.0f;

        //cast a ray downwards of length 1
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, rayLength, groundLayerMask);

        if (hit.collider == null)
        {
            Debug.DrawRay(transform.position, -Vector2.up * rayLength, Color.black);
            
            return false;
        }
        Debug.DrawRay(transform.position, -Vector2.up * rayLength, Color.red);
        
        return true;
    }

    public void FlipObject(bool flip)
    {
        // get the SpriteRenderer component
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}