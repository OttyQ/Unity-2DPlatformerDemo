using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShrinePart : MonoBehaviour
{
    [SerializeField] UnityEvent ActivateShrine;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ActivateShrine.Invoke();     
        }
    }
}
