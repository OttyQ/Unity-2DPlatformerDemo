using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class Hero : MonoBehaviour
{
    //main parameters
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    public Animator animator;
    public BoxCollider2D groundCheck;// check for graound
    public LayerMask groundMask; //what we check in groundCheck
    enum PlayerState {Idle, Run, Airborne, Dash}
    PlayerState state;
    public bool grounded;
    bool stateComplete;

    //dash parameters
    public bool canDash = true;
    public bool isDashing = false;
    public float DashingPower = 20f;
    public float DashingTime = 0.2f;
    public float DashingCooldown = 1f;
    


    [SerializeField] float groundSpeed = 3f;
    [Range(0f, 1f)] public float groundDecay;

    [SerializeField] float jumpForce = 15f;

   

    float xInput; 
    float yInput;



    void Update()
    {
        CheckInput();
        HandleJump();
        

        if(stateComplete){
            SelectState();
        }
        UpdateState();
    }
     void FixedUpdate(){
        CheckGround();
        HandleDash();    
        HandleXMove(); 
           
    } 


    void UpdateState(){
        switch(state){
            case PlayerState.Idle:
                UpdateIdle();
                break;
            case PlayerState.Run:
                UpdateRun();
                break;
            case PlayerState.Airborne:
                UpdateAirborne();
                break;
            case PlayerState.Dash:
                UpdateDash();
                break;
        }
    }
    private void CheckInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }


    void SelectState(){
        stateComplete = false;
        //main hero control
        
        if(grounded){
            if(xInput == 0){
                Debug.Log("Start Idle!");
                state = PlayerState.Idle;
                StartIdle();
            }else {
                state = PlayerState.Run;
                StartRun();
            } 
        } else {
            Debug.Log("Airborn Start!");
            state = PlayerState.Airborne;
            StartAirborne();
        } 
    }


    void StartIdle(){
        animator.Play("Idle");
    }
    void StartRun(){
        animator.Play("Run");
    }
    void StartAirborne(){
        animator.Play("Jump");
    }
    void StartDash(){
        animator.Play("Dash");
    }
    void UpdateIdle(){
        if(!grounded || xInput != 0 || state == PlayerState.Dash){
            stateComplete = true;
        }
    }
    void UpdateRun(){
        if(!grounded || xInput == 0){
            stateComplete = true;
        }
    }
    void UpdateAirborne(){
        float time  = Helper.Map(rb.velocity.y, jumpForce, -jumpForce, 0,1,true);
        animator.Play("Jump", 0, time);
        if(grounded || state == PlayerState.Dash){
            stateComplete = true;
        }
    }
    void UpdateDash(){
        if(canDash){
            rb.velocity = new Vector2(0,rb.velocity.y);
            Debug.Log("Dash complete");
            stateComplete = true;
        }
    }


    void HandleXMove(){
        if(Mathf.Abs(xInput)>0){
            float newSpeed = xInput * groundSpeed;
            rb.velocity = new Vector2(newSpeed, rb.velocity.y);
            //if(grounded)State = States.run; //анимация бега

            //разворот спрайта по направлению движения
            float direction = Mathf.Sign(xInput);
            transform.localScale = new Vector3(direction,1,1);
        }

        
    }
    void HandleJump(){
        if(Input.GetButtonDown("Jump") && grounded){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    void HandleDash(){
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash) 
        {
            StartCoroutine(DashCor());        
        }
    }
    void CheckGround(){
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
        
    }
    public IEnumerator DashCor()
    {
        state = PlayerState.Dash;
        StartDash();
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * DashingPower, 0f);
        yield return new WaitForSeconds(DashingTime);
        rb.gravityScale = originalGravity;
        Debug.Log("Gravity change to original");
        isDashing = false;
        rb.velocity = new Vector2(0,rb.velocity.y);
        stateComplete = true;
        yield return new WaitForSeconds(DashingCooldown);
        canDash = true;
    }
}
