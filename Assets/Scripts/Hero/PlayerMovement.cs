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

    

    private bool isInputBlocked = false ;
    private PlayerDash playerDash;

    private void Start()
    {
        pauseMenu = gameManager.GetComponent<PauseMenu>();
    }

    private void Update()
    {
        if (pauseMenu.isPause || isInputBlocked) return;

        HandleMovementInput();
        FlipCharacter();

        
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
        if (!PlayerDash.instance.IsDashing())
        {
            horizontalInput = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            sfxHero.Hero_jump_start();
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            grounded = false;
        }
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

    

    public void BlockInput() => isInputBlocked = true;

    public void UnblockInput() => isInputBlocked = false;
}
