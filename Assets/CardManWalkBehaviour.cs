using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManWalkBehaviour : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    GameObject emilyGameObject;
    CharacterController characterController;
    float speed;
    float attackRadius;
    bool attackTriggered;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        emilyGameObject = GameObject.FindGameObjectWithTag("Player");
        characterController = animator.GetComponent<CharacterController>();
        speed = animator.GetComponent<CardMan>().speed;
        attackRadius = animator.GetComponent<CardMan>().attackRadius;
        attackTriggered = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 difference = emilyGameObject.transform.position - animator.transform.position;
        difference.y = 0;
        characterController.SimpleMove(difference.normalized*speed);
        Vector3 emilyLookPosition = emilyGameObject.transform.position;
        emilyLookPosition.y = animator.transform.position.y;
        animator.transform.LookAt(emilyLookPosition);
        if(!attackTriggered && difference.sqrMagnitude < attackRadius)
        {
            animator.SetTrigger("Attack");
            attackTriggered = true;
        }
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
