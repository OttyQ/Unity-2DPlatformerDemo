using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Hero hero;
    public Rigidbody2D rb;
    public bool canDash = true;
    public bool isDashing = false;
    public float DashingPower = 20f;
    public float DashingTime = 0.2f;
    public float DashingCooldown = 1f;

    

    private void Start()
    {
        hero = GetComponent<Hero>();

        if (hero != null)
        {
            rb = hero.rb; // Получить ссылку на Rigidbody2D из Hero
        }
        else
        {
            Debug.LogError("Hero reference is not assigned.");
        }
    }
    public void Update()
    {
        if (isDashing)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash) 
        {
            StartCoroutine(DashCor());        
        }
    }
    public IEnumerator DashCor()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * DashingPower, 0f);
        yield return new WaitForSeconds(DashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(DashingCooldown);
        canDash = true;
    }

}