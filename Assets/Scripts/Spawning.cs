using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawning : MonoBehaviour
{
    [SerializeField] float heightdie = -20f;
    [Header ("Health")]
    [SerializeField] UnityEvent heroHealth;



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
        Debug.Log("Start position: " + CheckPointPos);                          
    }

    void Update()
    {
        Checkheight();
    }

    public void Checkheight()
    {            
        if (transform.position.y < heightdie)
        {
            heroHealth.Invoke();                 
        }
    }
    public void HandleRespawn()
    {
        hero.body.velocity = Vector2.zero;
        transform.position = CheckPointPos;
    }

    public void UpdateCheckPoint(Vector2 pos)
    {
        if (CheckPointPos != pos)
        {
            Debug.Log("Updating checkpoint to: " + pos);
            CheckPointPos = pos;
        }
    }

    
}
