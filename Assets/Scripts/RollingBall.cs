using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBall : MonoBehaviour, IControllerCollider
{
    [SerializeField] float forceMultiplier;
    Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void CalculateCollision(ControllerColliderHit hit, EmilyTriggerController emilyTriggerController)
    {
        rigidbody.AddForce(hit.moveDirection * hit.moveLength * forceMultiplier);
    }
}
