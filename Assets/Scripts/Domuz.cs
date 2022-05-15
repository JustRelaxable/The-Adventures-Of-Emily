using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Domuz : MonoBehaviour,IAttackable
{
    [SerializeField] Transform rockTransform;
    [SerializeField] GameObject rockPrefab;
    [SerializeField] float rockTargetHeight;
    [SerializeField] float rockForceMultiplier;
    [SerializeField] float domuzRockAngleFix;
    [SerializeField] int domuzHitPoint;

    private CharacterController characterController;
    private Animator animator;
    private GameObject emily;
    private GameObject instantiatedRock;

    private void Awake()
    {
        emily = GameObject.FindGameObjectWithTag("Player");
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
    }

    public void EmilyEnteredWarZone()
    {
        animator.SetTrigger("EmilyEnteredWarZone");
    }

    public void InstantiateRock()
    {
        instantiatedRock = Instantiate(rockPrefab, rockTransform);
        instantiatedRock.GetComponent<DomuzRock>().InitializeRock(this);
        instantiatedRock.GetComponent<Rigidbody>().isKinematic = true;
        instantiatedRock.transform.localPosition = Vector3.zero;
        instantiatedRock.transform.localRotation = Quaternion.identity;
    }

    public void ThrowTheRock()
    {
        Vector3 midVector = (emily.transform.position - transform.position)/2;
        midVector.y += rockTargetHeight;
        midVector = Quaternion.Euler(0, domuzRockAngleFix, 0) * midVector;
        instantiatedRock.transform.parent = null;
        Vector3 forceVector = ((transform.position + midVector) - instantiatedRock.transform.position) * rockForceMultiplier;
        Rigidbody instantiedRockRigidbody = instantiatedRock.GetComponent<Rigidbody>();
        instantiedRockRigidbody.isKinematic = false;
        instantiedRockRigidbody.AddForce(forceVector);
    }

    public void PerformAttackResult()
    {
        animator.SetTrigger("HitByEmily");
        domuzHitPoint--;
        if(domuzHitPoint == 0)
        {
            DomuzDie();
        }
    }

    public void OnSuccessfullEmilyHit()
    {
        animator.SetTrigger("DomuzRockHit");
    }

    private void DomuzDie()
    {
        animator.SetTrigger("DomuzKilled");
    }
}
