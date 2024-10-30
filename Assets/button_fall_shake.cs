using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_fall_shake : StateMachineBehaviour
{
    private Animator cameraAnim;
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject obj = GameObject.FindWithTag("MainCamera");
        cameraAnim = obj.GetComponent<Animator>();
        animator.SetTrigger("Shake");
    }
}
