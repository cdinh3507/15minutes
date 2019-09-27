using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

    public bool hasFired = false;
    public GameObject player;
    public float range = 10f;
    public GameObject meteor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if player in range of spawner create meteor
        if ((player.transform.position.x < transform.position.x) && 
            (transform.position.x - range < player.transform.position.x) &&
            !hasFired)
        {
            FindObjectOfType<AudioManager>().Play("MeteorFall");
            Instantiate(meteor, transform.position, transform.rotation);
            hasFired = true;

        }
    }
}
