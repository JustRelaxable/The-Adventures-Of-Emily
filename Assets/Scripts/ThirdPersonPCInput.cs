using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonPCInput : ThirdPersonInput
{
    private float horizontalInput,verticalInput;
    public override bool JumpHold { get; protected set; }
    public bool JumpActive { get; set; } = true;
    public override event Action JumpPressed;
    public override event Action AttackPressed;
    public override event Action EPressed;

    public override float HorizontalInput { get; protected set; }
    public override float VerticalInput { get; protected set; }
    private void Update()
    {
        CalculateMovementInputs();
        CalculateJumpHold();
        CalculateJumpPressed();
        CalculateAttackPressed();
        CalculateEPressed();
    }

    private void CalculateAttackPressed()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AttackPressed?.Invoke();
        }
    }

    private void CalculateEPressed()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EPressed?.Invoke();
        }
    }

    protected override void CalculateJumpPressed()
    {
        if (JumpActive && Input.GetKeyDown(KeyCode.Space))
        {
            JumpPressed?.Invoke();
        }
    }

    protected override void CalculateMovementInputs()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
    }

    protected override void CalculateJumpHold()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            JumpHold = true;
        }
        else
        {
            JumpHold = false;
        }
    }
}

public struct MovementInput
{
    public float horizontal, vertical;
}
