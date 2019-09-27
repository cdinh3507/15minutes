using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWait : MonoBehaviour
{

    public float xNew = 0f;
    public float yNew = 0f;
    public float speed = 1f;
    Vector3 target;
    public float startX;
    public float startY;
    public bool seen = false;

    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
        target = new Vector3(xNew, yNew, 0f);
    }

    void OnBecameVisible()
    {
        //seen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (seen)
        {
                transform.position = Vector3.MoveTowards(transform.position, target, speed);
        }
          
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            seen = true;
        }
    }
}
