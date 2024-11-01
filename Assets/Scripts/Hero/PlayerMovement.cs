using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private BoxCollider2D groundCheck;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private SFX_Hero sfxHero;

    private PauseMenu pauseMenu;
    private float horizontalInput;
    public bool grounded { get; private set; }

    [Header("Dash Parameters")]
    private bool isDashing;
    private bool canDash = false;
    private float dashDuration = 0.2f;
    [SerializeField] private float dashForce;
    [SerializeField] private float dashCooldown = 1f;

    private bool isInputBlocked = false;

    private void Start()
    {
        pauseMenu = gameManager.GetComponent<PauseMenu>();
    }

    private void Update()
    {
        if (pauseMenu.isPause || isInputBlocked) return;

        HandleMovementInput();
        FlipCharacter();

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            StartCoroutine(Dash());
    }

    private void FixedUpdate()
    {
        if (pauseMenu.isPause || isInputBlocked) return;

        CheckGroundStatus();
        HandleJump();
        animator.SetBool("isRun", Mathf.Abs(horizontalInput) > 0.01f);
        animator.SetBool("grounded", grounded);
    }

    private void HandleMovementInput()
    {
        if (!isDashing)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        }
    }

    private void HandleJump()
    {
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            sfxHero.Hero_jump_start();
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            grounded = false;
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;
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
    }

    private void FlipCharacter()
    {
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void CheckGroundStatus()
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
    }

    public void EnableDash() => canDash = true;

    public void BlockInput() => isInputBlocked = true;

    public void UnblockInput() => isInputBlocked = false;
}
