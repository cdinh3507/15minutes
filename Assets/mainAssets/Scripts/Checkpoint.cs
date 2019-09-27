using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public LevelManager levelManager;
    public Animator animator;
    bool done = false;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            levelManager.currentCheckpoint = gameObject;
            if (!done)
            {
                FindObjectOfType<AudioManager>().Play("Checkpoint");
            }
            animator.SetBool("touch", true);
        }
        
    }

    public void Done()
    {
        animator.SetBool("doneClose", true);
        done = true;


    }

    
}
