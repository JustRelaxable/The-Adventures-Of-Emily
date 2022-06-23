using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomuzThrowBehaviour : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    private GameObject emily;
    private float maxDistanceToEmily = 3;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        emily = GameObject.FindGameObjectWithTag("Player");
        animator.SetBool("EmilyWatching", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 lookPosition = new Vector3(emily.transform.position.x, animator.transform.position.y, emily.transform.position.z);
        animator.transform.LookAt(lookPosition);
        Vector3 vectorToEmily = emily.transform.position - animator.transform.position;
        animator.SetFloat("DistanceToEmily", vectorToEmily.magnitude);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("EmilyWatching", false);
    }

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
