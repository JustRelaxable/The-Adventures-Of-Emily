using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ThirdPersonInput : MonoBehaviour
{
    public abstract bool JumpHold { get; protected set; }
    public abstract event Action JumpPressed;
    public abstract event Action AttackPressed;
    public abstract float VerticalInput { get; protected set; }
    public abstract float HorizontalInput { get; protected set; }
    protected abstract void CalculateMovementInputs();
    protected abstract void CalculateJumpPressed();
    protected abstract void CalculateJumpHold();
}
