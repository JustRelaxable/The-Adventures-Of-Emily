using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmilyTriggerController : MonoBehaviour, IAttackable
{
    [SerializeField] EmilyAnimator emilyAnimator;
    [SerializeField] ThirdPersonMovement thirdPersonMovement;
    public void PerformAttackResult()
    {
        emilyAnimator.Hit();
        thirdPersonMovement.Hit();
    }
}
