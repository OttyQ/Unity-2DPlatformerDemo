using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinKing_Attack_ : StateMachineBehaviour
{
    [SerializeField] private float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;
    private GoblinKing_Attack bossAttack;



    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossAttack = animator.GetComponent<GoblinKing_Attack>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer >= attackCooldown)
        {
            animator.SetTrigger("CanAttack");
            cooldownTimer = 0;
            bossAttack.Attack();
            
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("CanAttack");
    }


}
