using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSlide : MonoBehaviour
{
    public float dirX, moveSpeed = 3f;
    public bool side = true;
    public bool up = false;
    bool moveRight = true;
    bool moveUp = true;
    bool seen = false;
    public float upDis = 2f;
    public float sideDis = 2f;

    float startX;
    float startY;

    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
    }

    void OnBecameVisible()
    {
        seen = true;
    }

    // Update is called once per frame
    void Update()
    {
  
        if (seen)
        {
            if (side)
            {
                if (transform.position.x > startX + sideDis)
                    moveRight = false;
                if (transform.position.x < startX - sideDis)
                    moveRight = true;

                if (moveRight)
                    transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
                else
                    transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
            }

            if (up)
            {
                if (transform.position.y > startY + upDis)
                    moveUp = false;
                if (transform.position.y < startY - upDis)
                    moveUp = true;

                if (moveUp)
                    transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
                else
                    transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
            }
        }
    }
}
