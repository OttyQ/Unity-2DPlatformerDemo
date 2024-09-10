using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    [SerializeField] float heightdie = -20f;
    Vector2 CheckPointPos;
    public PlayerMovement hero;
    public void Start()
    {

        hero = GameObject.FindObjectOfType<PlayerMovement>();

        if (hero == null)
        {
            Debug.LogError("Hero not found!");
            return;
        }
        CheckPointPos = transform.position;
        Debug.Log("Start position: " + CheckPointPos); //                           
    }

    void Update()
    {
        Checkheight(); //                            

        //if (hero.lives <= 0)
        //{
        //    DieFall();
        //}
    }

    public void Checkheight()
    {
        //Debug.Log("Checking height: " + transform.position.y); //                
        if (transform.position.y < heightdie)
        {
            DieFall();                     
        }
    }

    public void DieFall()
    {
        Debug.Log("DieFall triggered");
        StartCoroutine(Respawn(0.5f)); 
    }

    IEnumerator Respawn(float duration)
    {
        Debug.Log("Respawn started, waiting for " + duration + " seconds.");
        yield return new WaitForSeconds(duration);
        Debug.Log("Respawning to position: " + CheckPointPos);
        transform.position = CheckPointPos;
    }

    public void UpdateCheckPoint(Vector2 pos)
    {
        Debug.Log("Updating checkpoint to: " + pos);
        CheckPointPos = pos;
    }
}