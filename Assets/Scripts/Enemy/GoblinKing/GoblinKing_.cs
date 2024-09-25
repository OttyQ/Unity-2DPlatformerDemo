using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoblinKing_ : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject hpBar;
    public bool isFlipped = false;
    Rigidbody2D rb;

    private void OnEnable()
    {
        hpBar.SetActive(true);
    }
    private void OnDisable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && !isFlipped)
        {
            Flip();
        }
        else if (transform.position.x < player.position.x && isFlipped)
        {
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        transform.localScale = flipped;
        transform.Rotate(0f, 180f, 0f);
        isFlipped = !isFlipped;
    }
}
