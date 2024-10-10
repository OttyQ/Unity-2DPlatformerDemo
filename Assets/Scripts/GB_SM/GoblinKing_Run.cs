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
    private float cooldownTimer = Mathf.Infinity;

    [Header("Charged Attack parameters")]
    [SerializeField] bool canChargedAttack = false;
    [SerializeField] float chargedAttackCooldown;
    

    [Header("Collider references")]
    private BoxCollider2D attackCollider; // Коллайдер атаки
    private BoxCollider2D chargedAttackCollider; // Коллайдер заряженной атаки
    private Collider2D playerCollider; // Коллайдер игрока

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        goblinKing = animator.GetComponent<GoblinKing_>();
        attackCollider = animator.transform.Find("AttackCollider").GetComponent<BoxCollider2D>();
        chargedAttackCollider = animator.transform.Find("ChAttackCol").GetComponent<BoxCollider2D>();
        playerCollider = player.GetComponentInChildren<Collider2D>();
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
        if (attackCollider.IsTouching(playerCollider))
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                rb.velocity = Vector2.zero; // Остановка перед атакой
                animator.SetTrigger("CanAttack");
                animator.SetTrigger("Attack");
            }
        }


        if (canChargedAttack && chargedAttackCollider.IsTouching(playerCollider))
        {
            if (cooldownTimer >= chargedAttackCooldown && canChargedAttack)
            {
                cooldownTimer = 0;
                rb.velocity = Vector2.zero; // Остановка перед атакой
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
