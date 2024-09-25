using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GoblinKing_Run : StateMachineBehaviour
{

    Transform player;
    Rigidbody2D rb;
    [SerializeField] float speed;
    GoblinKing_ goblinKing;

    [Header ("Attack parameters")]
    [SerializeField] float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] float attackRange;




    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        goblinKing = animator.GetComponent<GoblinKing_>();

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        goblinKing.LookAtPlayer();
        Vector2 target =  new Vector2(player.position.x, rb.velocity.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);


        cooldownTimer += Time.deltaTime;
        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                rb.velocity = Vector2.zero;
                animator.SetTrigger("CanAttack");
                animator.SetTrigger("Attack");
                //Physics2D.IgnoreLayerCollision(7, 8, true);
            }
            
        }

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("CanAttack");
        rb.velocity = Vector2.zero;
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}
