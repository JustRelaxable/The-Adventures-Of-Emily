using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmilyAnimator : MonoBehaviour
{
    [SerializeField] private ThirdPersonMovement emilyMovement;
    [SerializeField] private ThirdPersonInput thirdPersonInput;
    public event Action OnStepped;
    private Animator animator;
 
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        thirdPersonInput.JumpPressed += ThirdPersonInput_JumpPressed;
        thirdPersonInput.AttackPressed += () => { animator.SetTrigger("AttackTest"); };
    }

    private void ThirdPersonInput_JumpPressed()
    {
        if (!emilyMovement.FirstJump && !emilyMovement.SecondJump)
        {
            animator.SetTrigger("Jump");
        }
        else if (emilyMovement.FirstJump && !emilyMovement.SecondJump)
        {
            animator.SetTrigger("Jump");
        }
    }

    private void Update()
    {
        animator.SetFloat("TurnSmoothVelocity", emilyMovement.TurnSmoothVelocity);
        animator.SetFloat("vSpeed", emilyMovement.VerticalSpeed);
        CalculateAnimatorRunningState();
        CalculateAnimatorGroundedState();
    }

    private void CalculateAnimatorGroundedState()
    {
        if (emilyMovement.IsGrounded)
        {
            animator.SetBool("IsGrounded", true);
        }
        else
        {
            animator.SetBool("IsGrounded", false);
            if (thirdPersonInput.JumpHold && emilyMovement.VerticalSpeed <= 0)
                animator.SetBool("SpaceDown", true);
            else
                animator.SetBool("SpaceDown", false);
        }
    }

    private void CalculateAnimatorRunningState()
    {
        if (emilyMovement.CharacterDirection.magnitude <= 0.1f)
        {
            animator.SetBool("Running", false);
        }
        else
        {
            animator.SetBool("Running", true);
        }
    }

    private void TriggerOnStepped()
    {
        OnStepped?.Invoke();
    }
}
