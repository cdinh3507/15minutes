using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;

    private CharacterController player;

    public Animator animator;

    private Collision2D collision;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer(Collision2D col)
    {
        Debug.Log("Player Respawn");
        animator.SetBool("isDead", true);
        collision = col;
        FindObjectOfType<AudioManager>().Play("Death");
    }

    public void RespawnLocation()
    {
        collision.transform.position = currentCheckpoint.transform.position;
        //find all meteor spawners and reset them
        GameObject[] GOs = GameObject.FindGameObjectsWithTag("MeteorSpawn");
        // now all your game objects are in GOs,
        // all that remains is to getComponent of each and every script and you are good to go.
        // to disable a components
        for (int i = 0; i < GOs.Length; i++)
        {
            GOs[i].GetComponent<MeteorSpawner>().hasFired = false;
        }

        //find all mvplat and reset them
        GameObject[] GOmps = GameObject.FindGameObjectsWithTag("mvPlatform");
        // now all your game objects are in GOs,
        // all that remains is to getComponent of each and every script and you are good to go.
        // to disable a components
        for (int i = 0; i < GOmps.Length; i++)
        {
 
            GOmps[i].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            if (GOmps[i].GetComponent<Rotate>() != null)
            {
                GOmps[i].GetComponent<Rotate>().seen = false;
            }
            if (GOmps[i].GetComponent<MoveWait>() != null)
            {
                GOmps[i].GetComponent<MoveWait>().seen = false;
                GOmps[i].transform.position = new Vector3(GOmps[i].GetComponent<MoveWait>().startX, GOmps[i].GetComponent<MoveWait>().startY, 0f);
            }
            //GOmps[i].transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
