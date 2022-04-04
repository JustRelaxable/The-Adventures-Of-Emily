using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    public ThirdPersonMovement thirdPersonMovement;
    public int jumpForce;

    public void ApplyPot()
    {
        thirdPersonMovement.JumpForce = jumpForce;
    }
}
