using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmilyAnimator : MonoBehaviour
{
    public GameObject TargetGameObject { get; set; }

    [SerializeField] private ThirdPersonMovement emilyMovement;
    [SerializeField] private ThirdPersonInput thirdPersonInput;
    [SerializeField] private EmilyAttackController emilyAttackController;
    public event Action OnStepped;
    private Animator animator;
    private bool EmilyParalysed { get => !emilyMovement.CanMove; }
    public bool EmilyAttackEnabled { get; set; } = true;
    public bool isDig = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        thirdPersonInput.JumpPressed += ThirdPersonInput_JumpPressed;
        thirdPersonInput.AttackPressed += () =>
        {
            if (animator.GetBool("HoldingItem"))
                return;
            if (!EmilyAttackEnabled)
                return;
            if (EmilyParalysed)
                return;
            if (isDig)
            {
                animator.SetTrigger("Dig");
                return;
            }

            animator.SetTrigger("AttackTest");
        };
        thirdPersonInput.EPressed += () =>
        {
            if (animator.GetBool("Pickable"))
            {
                animator.SetTrigger("EPressed");
            }
        };
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

    public void SetBool(string boolKey, bool value)
    {
        animator.SetBool(boolKey, value);
    }

    public void PickUp()
    {
        TargetGameObject.GetComponent<IPickable>().PerformPickAction();
        animator.SetBool("Pickable", false);
        GetComponent<EmilyObjectHoldController>().HoldObject(TargetGameObject);
    }

    public void Attack()
    {
        if (EmilyParalysed)
            return;
        emilyAttackController.Attack();
    }

    public void Hit()
    {
        animator.SetTrigger("Hit");
    }

    public void DisableMovement()
    {
        emilyMovement.CanMove = false;
    }

    public void EnableMovement()
    {
        emilyMovement.CanMove = true;
    }
}
