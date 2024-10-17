using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    public BoxCollider2D groundCheck;// check for graound
    public LayerMask groundMask; //what we check in groundCheck
    public bool grounded;
    float horizontalInput;
    public Animator animator;

    [Header ("Dash params")]
    private bool isDashing = false;
    public bool canDash = true;
    [SerializeField] private float dashForce;
    [SerializeField] private float dashCooldown = 1f;
    
    [SerializeField] private GameObject gameManager;
    private PauseMenu pauseMenu;

    private void OnDisable(){
        body.velocity = Vector2.zero;
        animator.SetBool("grounded", true);
    }

    private void Start()
    {
        pauseMenu = gameManager.GetComponent<PauseMenu>();
    }

    void FixedUpdate(){
        //pause check
        if (!pauseMenu.isPause)
        {
            GroundCheck();
            HandleJump();

            animator.SetBool("isRun", horizontalInput != 0);
            animator.SetBool("grounded", grounded);
        }
    }
    private void Update(){
        //pause check
        if (!pauseMenu.isPause)
        {
            HandleXMove();
            bodyFlip();

            if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && canDash)
            {

                animator.SetTrigger("Dashing");
                StartCoroutine(Dash());
            }
        }
    }


    void HandleXMove(){
        if(!isDashing){
            horizontalInput = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(horizontalInput * speed,body.velocity.y);
            
        }
    }

    void HandleJump(){
        if(Input.GetKey(KeyCode.Space) && grounded){
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            //animator.SetTrigger("Jump");
            grounded = false;
        }
    }
    IEnumerator Dash(){
        isDashing = true;
        canDash = false;
        animator.SetBool("isDashing", isDashing);
        float originalGravity = body.gravityScale;
        body.gravityScale = 0f;
        float dashDuration = 0.2f; // Adjust as needed
        body.velocity = new Vector2(transform.localScale.x * dashForce, 0f);

        yield return new WaitForSeconds(dashDuration);
        body.gravityScale = originalGravity;
        body.velocity = Vector2.zero;
        isDashing = false;
        animator.SetBool("isDashing", isDashing);
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
    void bodyFlip(){ 
        if(horizontalInput > 0.01f){
            transform.localScale = Vector3.one;
        } else if(horizontalInput < -0.01f){
            transform.localScale = new Vector3(-1,1,1);
        }
        
    }

    void GroundCheck(){
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
        //Debug.Log("Animator set grounded = " + grounded);
    }
    
}
