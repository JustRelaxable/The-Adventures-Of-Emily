using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NutcrackerWalkingBehaviour : StateMachineBehaviour
{
    private GameObject emily;
    private NavMeshAgent navMeshAgent;
    private float attackDistance;
    private bool attackPerformed;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        emily = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = animator.GetComponent<NavMeshAgent>();
        attackDistance = animator.GetComponent<NutCracker>().AttackDistance;
        attackPerformed = false;
        animator.GetComponent<NutCracker>().NutCrackerSword.CanHit = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        navMeshAgent.SetDestination(emily.transform.position);
        if (!attackPerformed && (emily.transform.position - animator.transform.position).magnitude < attackDistance)
        {
            attackPerformed = true;
            animator.SetTrigger("SwordAttack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        navMeshAgent.SetDestination(animator.transform.position);
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
