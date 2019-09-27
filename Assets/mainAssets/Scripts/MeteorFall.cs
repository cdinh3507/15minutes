using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFall : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
    public GameObject player;
    public Animator animator;
    public Collider2D DisableCollider;
    public float speed = 10;
    public float gravity = .4f;
    public float range = 10f;
    bool start = false;
    bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        //m_Rigidbody2D.gravityScale = 0f;
    }

    public void ImpactDone()
    {
        animator.SetBool("impactDone", true);
        Destroy(gameObject);
    }

    public void DamageDone()
    {
        if (DisableCollider != null)
        {
            DisableCollider.enabled = false;
        }
        FindObjectOfType<AudioManager>().Play("MeteorImpact");

    }

    // Update is called once per frame
    void Update()
    {

        //if (start) {
            if (done)
            {
                animator.SetBool("impact", true);
                m_Rigidbody2D.velocity = new Vector2(0f, m_Rigidbody2D.velocity.y);
            }
            else
            {
                m_Rigidbody2D.velocity = new Vector2(-1 * speed, m_Rigidbody2D.velocity.y);
            }

        //}

 
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        done = true;
    }

}
