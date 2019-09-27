/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    public float distance = 1f;
    public CharacterController2D movement;
    public float speed = 2f;
    bool walljumping;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.raycastsStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, 
            Vector2.right * transform.localScale.x, distance);

        if (Input.GetKeyDown("Jump") && !movement.m_Grounded && hit.collider != null)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed * hit.normal.x, speed);
            movement.BaseSpeed = speed * hit.normal.x;
            walljumping = true;
            transform.localScale = transform.localScale.x == 1 ? new Vector2(-1, 1) : Vector2.one;
        }
        else if (hit.collider != null && walljumping)
            walljumping = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!walljumping || movement.grounded)
        {
            movement.BaseSpeed = 0;
        }
    }
}*/

