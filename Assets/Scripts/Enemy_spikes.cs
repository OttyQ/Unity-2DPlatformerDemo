using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Enemy_spikes : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private Health playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }



}
