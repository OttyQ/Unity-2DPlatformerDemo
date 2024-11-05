using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wake_Up_SM : StateMachineBehaviour
{
    private PlayerMovement playerMovement;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerMovement = animator.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.BlockInput();
        }
        else
        {
            Debug.LogWarning("PlayerMovement component not found on GameObject with Animator.");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerMovement != null)
        {
            playerMovement.UnblockInput();
        }
    }
}
