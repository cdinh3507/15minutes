using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public LevelManager levelManager;

    void Start ()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    
    //[SerializeField]Transform spawnPoint;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            
            //col.transform.position = spawnPoint.position;
            levelManager.RespawnPlayer(col);
        }
    }
}
