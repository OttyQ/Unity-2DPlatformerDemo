using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawning : MonoBehaviour
{
    [SerializeField] private float heightDie = -20f;

    [Header("Health")]
    [SerializeField] private UnityEvent heroHealth;

    public Vector2 CheckPointPos { get; private set; }
    private PlayerMovement hero;

    private void Start()
    {
        hero = FindObjectOfType<PlayerMovement>();
        if (hero == null)
        {
            Debug.LogError("Hero not found!");
            return;
        }

        CheckPointPos = transform.position;
        Debug.Log("Start position: " + CheckPointPos);
    }

    private void Update()
    {
        CheckHeight();
    }

    private void CheckHeight()
    {
        if (transform.position.y < heightDie)
        {
            heroHealth?.Invoke();
        }
    }

    public void HandleRespawn()
    {
        transform.position = CheckPointPos;
    }

    public void UpdateCheckPoint(Vector2 newCheckPointPos)
    {
        if (CheckPointPos != newCheckPointPos)
        {
            Debug.Log("Updating checkpoint to: " + newCheckPointPos);
            CheckPointPos = newCheckPointPos;
        }
    }
}
