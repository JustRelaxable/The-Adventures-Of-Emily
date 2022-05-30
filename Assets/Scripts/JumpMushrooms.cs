using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMushrooms : MonoBehaviour,IControllerCollider
{
    [SerializeField] float forceMultiplier;
    [SerializeField] float cooldownTime;
    private float countTime;

    public void CalculateCollision(ControllerColliderHit hit,EmilyTriggerController emilyTriggerController)
    {
        if (Time.time - countTime > cooldownTime)
        {
            emilyTriggerController.AddToImpact(Vector3.up * forceMultiplier);
            hit.controller.GetComponent<ThirdPersonMovement>().ResetVerticalSpeed();
            countTime = Time.time;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("xxx");
        Rigidbody rigidbody;
        collision.gameObject.TryGetComponent<Rigidbody>(out rigidbody);
        if(rigidbody != null)
        {
            
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("xx");
    }
}
