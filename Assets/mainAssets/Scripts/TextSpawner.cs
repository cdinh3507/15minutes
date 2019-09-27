using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawner : MonoBehaviour
{

    bool hasFired = false;
    public GameObject player;
    public GameObject textObject;
    public float range = 40f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if player in range of spawner create meteor
        if ((player.transform.position.x < transform.position.x + range) &&
            (transform.position.x - range < player.transform.position.x) &&
            !hasFired)
        {

            textObject.GetComponent<TextCrawl>().StartText();
            hasFired = true;

        }
    }
}
