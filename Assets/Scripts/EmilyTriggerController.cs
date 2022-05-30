using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmilyTriggerController : MonoBehaviour, IAttackable
{
    [SerializeField] EmilyAnimator emilyAnimator;
    [SerializeField] ThirdPersonMovement thirdPersonMovement;
    private CharacterController characterController;
    Vector3 impact = Vector3.zero;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(impact.sqrMagnitude > 0.4f)
        {
            characterController.Move(impact * Time.deltaTime);
            impact = Vector3.Lerp(impact, Vector3.zero, Time.deltaTime);
        }
    }
    public void PerformAttackResult()
    {
        emilyAnimator.Hit();
        thirdPersonMovement.Hit();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        IControllerCollider controllerCollider;
        hit.gameObject.TryGetComponent<IControllerCollider>(out controllerCollider);
        if(controllerCollider != null)
        {
            controllerCollider.CalculateCollision(hit,this);
        }
    }

    public void AddToImpact(Vector3 vector3)
    {
        impact += vector3;
    }
}
