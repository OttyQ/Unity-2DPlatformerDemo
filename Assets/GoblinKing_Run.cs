using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinKing_Run : StateMachineBehaviour
{

    Transform player;
    Rigidbody2D rb;
    [SerializeField] float speed;
    GoblinKing_ goblinKing;

    [Header("Attack parameters")]
    [SerializeField] float attackCooldown;
    [SerializeField] float attackRange;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Charged Attack parameters")]
    [SerializeField] bool canChargedAttack = false;
    [SerializeField] float chargedAttackCooldown;
    [SerializeField] float chargedAttackRange;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        goblinKing = animator.GetComponent<GoblinKing_>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        goblinKing.LookAtPlayer();

        // Приведение позиции игрока к Vector2
        Vector2 playerPosition2D = new Vector2(player.position.x, player.position.y);
        Vector2 direction = (playerPosition2D - rb.position).normalized;
        Vector2 velocity = new Vector2(direction.x * speed, rb.velocity.y);

        // Применение скорости
        rb.velocity = velocity;

        cooldownTimer += Time.deltaTime;

        // Атака, если игрок в радиусе
        if (Vector2.Distance(playerPosition2D, rb.position) <= attackRange)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                rb.velocity = Vector2.zero; // Остановка перед атакой
                animator.SetTrigger("CanAttack");
                animator.SetTrigger("Attack");
            }
        }
        if (Vector2.Distance(playerPosition2D, rb.position) <= chargedAttackRange)
        {
            if (cooldownTimer >= chargedAttackCooldown && canChargedAttack)
            {
                cooldownTimer = 0;
                rb.velocity = Vector2.zero;
                animator.SetTrigger("CanChargedAttack");
                animator.SetTrigger("Attack");

            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("CanAttack");
        animator.ResetTrigger("CanChargedAttack");
        rb.velocity = Vector2.zero; // Остановка при выходе из состояния
    }
}
