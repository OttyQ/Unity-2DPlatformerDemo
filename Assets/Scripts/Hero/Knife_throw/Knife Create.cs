using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCreate : MonoBehaviour
{
    public GameObject KnifePrefab;
    [SerializeField] private float KnifeSpeed = 10f;
    [SerializeField] private float KnifeCooldown = 1f;
    private float nextKnifeTime = 0f;
    private Transform playerTransform; 

    void Start()
    {
        playerTransform = transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time >= nextKnifeTime)
        {
            ThrowKnife(); 
            nextKnifeTime = Time.time + KnifeCooldown;
        }
    }

    void ThrowKnife()
    {
        GameObject knife = Instantiate(KnifePrefab, transform.position, transform.rotation);
        Rigidbody2D knifeRb = knife.GetComponent<Rigidbody2D>();

        if (knifeRb != null)
        {
            knifeRb.gravityScale = 0;
            float direction = playerTransform.localScale.x > 0 ? 1f : -1f;
            knifeRb.velocity = new Vector2(direction * KnifeSpeed, 0);
        }
    }
}
