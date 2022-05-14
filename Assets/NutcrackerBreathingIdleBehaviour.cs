using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutcrackerBreathingIdleBehaviour : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    private GameObject emily;
    private float emilyTargetRadius;
    private bool emilyInsideRadius = false;
    private CharacterController characterController;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        emily = GameObject.FindGameObjectWithTag("Player");
        emilyTargetRadius = animator.GetComponent<NutCracker>().EmilyTargetRadius;
        characterController = animator.GetComponent<CharacterController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!emilyInsideRadius && (animator.transform.position - emily.transform.position).magnitude < emilyTargetRadius)
        {
            animator.SetTrigger("EmilyInsideRadius");
            emilyInsideRadius = true;
        }
        characterController.SimpleMove(Vector3.zero);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
