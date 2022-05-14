using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomuzRunBehaviour : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    private GameObject emily;
    private float minZ = -10;
    private float maxZ = 12;
    private float minX = 54;
    private float maxX = 68;
    private float minDistanceToEmily = 10f;
    private Vector3 randomPosition;
    private Vector3 difference;
    private CharacterController characterController;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        characterController = animator.GetComponent<CharacterController>();
        emily = GameObject.FindGameObjectWithTag("Player");
        float distanceToEmily;
        float randomX;
        float randomZ;
        do
        {
            randomX = Random.Range(minX, maxX);
            randomZ = Random.Range(minZ, maxZ);
            Vector3 emilyWithoutY = new Vector3(emily.transform.position.x, 0, emily.transform.position.z);
            Vector3 randomWithoutY = new Vector3(randomX, 0, randomZ);
            distanceToEmily = (randomWithoutY - emilyWithoutY).magnitude;
        } while (distanceToEmily < minDistanceToEmily);
        randomPosition = new Vector3(randomX, 0, randomZ);
        difference = randomPosition - animator.transform.position;
        difference.y = 0;
        animator.SetBool("TargetCalculated", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        characterController.SimpleMove(difference.normalized*Time.deltaTime*200);
        Vector3 lookPosition = new Vector3(randomPosition.x, animator.transform.position.y, randomPosition.z);
        animator.transform.LookAt(lookPosition);
        Vector3 domuzWithoutY = new Vector3(animator.transform.position.x, 0, animator.transform.position.z);
        animator.SetFloat("TargetDistance", (randomPosition - domuzWithoutY).magnitude);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("TargetCalculated", false);
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
