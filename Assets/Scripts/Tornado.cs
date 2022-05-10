using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    [SerializeField] private float aliveTime;
    [SerializeField] private float velocity;
    private Rigidbody rigidbody;
    private Vector3 movementDirection;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, aliveTime);
    }

    public void InitializeMovementDirection(Vector3 movementDirection)
    {
        this.movementDirection = movementDirection;
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = movementDirection * velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        IAttackable attackable;
        if(other.TryGetComponent<IAttackable>(out attackable))
        {
            attackable.PerformAttackResult();
        }
    }
}
