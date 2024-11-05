using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public static PlayerDash instance;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject dashBar;

    [Header("Dash Parameters")]
    [SerializeField] private float dashRegenTime = 10f;
    private float totalDashAmount = 3;
    private float dashAmount = 2;
    private bool isDashing;
    private bool canDash = false;
    private float dashDuration = 0.2f;
    [SerializeField] private float dashForce = 15f;
    [SerializeField] private float dashCooldown = 1f;
    private Coroutine dashRegenCoroutine;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && dashAmount > 0)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;
        dashAmount--;
        float originalGravity = body.gravityScale;
        body.gravityScale = 0f;
        body.velocity = new Vector2(transform.localScale.x * dashForce, 0f);

        animator.SetBool("isDashing", isDashing);
        animator.SetTrigger("Dashing");

        yield return new WaitForSeconds(dashDuration); // dash duration

        body.gravityScale = originalGravity;
        body.velocity = Vector2.zero;
        isDashing = false;
        animator.SetBool("isDashing", isDashing);

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

        // «апуск корутины восстановлени€, если dashAmount меньше totalDashAmount
        if (dashAmount < totalDashAmount && dashRegenCoroutine == null)
        {
            dashRegenCoroutine = StartCoroutine(RegenerateDashAmount());
        }
    }

    public void EnableDash()
    {
        dashBar.SetActive(true);
        canDash = true;
    }

    public bool IsDashing()
    {
        return isDashing;
    }

    public float GetDashAmount()
    {
        return dashAmount;
    }

    public float GetTotalDashAmount()
    {
        return totalDashAmount;
    }

    public void AddDashAmount()
    {
        if (gameObject.activeInHierarchy && dashAmount < totalDashAmount)
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.dashRes);
            dashAmount += 1;

            // ќстанавливаем корутину, если dashAmount достиг максимума
            if (dashAmount >= totalDashAmount && dashRegenCoroutine != null)
            {
                StopCoroutine(dashRegenCoroutine);
                dashRegenCoroutine = null;
            }
        }
    }

    private IEnumerator RegenerateDashAmount()
    {
        while (dashAmount < totalDashAmount)
        {
            yield return new WaitForSeconds(dashRegenTime);
            AddDashAmount();
        }

        dashRegenCoroutine = null; // —брасываем переменную, когда восстановление завершено
    }
}
