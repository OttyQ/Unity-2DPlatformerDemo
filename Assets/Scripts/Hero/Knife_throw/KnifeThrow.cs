using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrow : MonoBehaviour
{
    public float lifetime = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            StickKnife();
        }

        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Knife hit the enemy!");
            Destroy(gameObject);
        }
    }
    void StickKnife()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.gravityScale = 0;
        rb.isKinematic = true;
        transform.SetParent(null);
    }
}
