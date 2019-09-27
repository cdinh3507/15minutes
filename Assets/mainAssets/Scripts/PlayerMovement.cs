using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public Rigidbody2D rigidbody;
    public LevelManager levelManager;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    float vertMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool slide = false;
    bool wall = false;
    bool onWall = false;
    bool wasWall = false;

    //slide time vars
    private float slideTimeCounter;
    public float slideTime;

    //walljump var
    public float wallDistance = 1f;
    public float wallSpeed = 2f;

    //slide time vars
    private float onWallTimeCounter = .3f;
    public float onWallTime = .3f;


    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        vertMove = rigidbody.velocity.y;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        animator.SetFloat("vertDir", vertMove);

        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position,
            Vector2.right * transform.localScale.x, wallDistance);

        if (!controller.m_Grounded && hit.collider != null)
        {
            if (!wasWall)
            {
                FindObjectOfType<AudioManager>().Play("SlidingLoop");
                wasWall = true;
            }
            animator.SetBool("isWall", true);
            if (onWall == false && onWallTimeCounter == onWallTime)
            {
                onWall = true;
                
            }
            else
            if (onWallTimeCounter > 0)
            {
                onWallTimeCounter -= Time.deltaTime;
            } else {
                onWall = false;
            }

            if (Input.GetButtonDown("Jump") && vertMove < 10)
            {
                wall = true;

            }
        }
        else
        {
            FindObjectOfType<AudioManager>().StopPlaying("SlidingLoop");
            wasWall = false;
            animator.SetBool("isWall", false);
            onWall = false;
            onWallTimeCounter = onWallTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;

        }

        if (Input.GetButtonDown("Slide") && crouch && !slide)
        {
            slide = true;
            animator.SetBool("isSlide", true);
            slideTimeCounter = slideTime;
            if (controller.m_Grounded) {
                FindObjectOfType<AudioManager>().Play("Sliding");
            }

        }

        if (Input.GetButtonDown("Crouch") || Input.GetAxisRaw("Vertical") < -.01)
        {

            crouch = true;

        }
        else if (Input.GetButtonUp("Crouch") || Input.GetAxisRaw("Vertical") >= -.01)
        {
            crouch = false;
        }

        if (slide && slideTimeCounter > 0)
        {
            slideTimeCounter -= Time.deltaTime;
        }
        else
        if (slide && slideTimeCounter <= 0)
        {
            slide = false;
            animator.SetBool("isSlide", false);
            slideTimeCounter = slideTime;
            
        }

    }

    public void OnLanding()
    {
        if (controller.m_Grounded && !jump && vertMove <= 0)
        {
           FindObjectOfType<AudioManager>().Play("Landing");
        }

    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouch", isCrouching);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("mvPlatform"))
            this.transform.parent = col.transform;

    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("mvPlatform"))
            this.transform.parent = null;
    }

    public void notDead()
    {
        animator.SetBool("isDead", false);
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;
        levelManager.RespawnLocation();
    }

    void FixedUpdate()
    {
        // Move our character
        animator.SetBool("isJump", !controller.m_Grounded);
        if (!animator.GetBool("isDead")) {

            rigidbody.gravityScale = 6f;
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, slide, wall, onWall);

        } else
        {
            rigidbody.gravityScale = 0f;
            Vector3 forceToAdd = new Vector3(0f, 0f, 0f);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            rigidbody.velocity = forceToAdd;

        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
        jump = false;
        wall = false;
    }
}

