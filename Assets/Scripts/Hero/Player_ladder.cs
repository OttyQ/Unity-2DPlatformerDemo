using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ladder : MonoBehaviour
{
    private float vertical;
    [SerializeField] private float speed;
    private bool isLadder;
    private bool isClimbing;
    private float normalGravScale;

    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        normalGravScale = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if(isLadder && Mathf.Abs(vertical) >= 0f)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = normalGravScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
