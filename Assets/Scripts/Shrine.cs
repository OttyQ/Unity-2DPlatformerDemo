using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine : MonoBehaviour
{
    [SerializeField] Spawning gameController;

    // public void Awake()
    // {
    //     //                      "Player"                      spawnfall
    //     gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<spawnfall>();
    //     //try to not use findObject with tag because it can take additional resources

    // }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (gameController != null)
        {
            gameController.UpdateCheckPoint(transform.position);
            Debug.Log("Checkpoint updated to position: " + transform.position);
        }
    }
}
