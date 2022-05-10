using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoMovement : MonoBehaviour
{
    [SerializeField] private float aliveTime;
    [SerializeField] private float velocity;
    private Rigidbody rigidbody;
    private Vector3 movementDirection;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void InitializeMovementDirection(Vector3 movementDirection)
    {
        this.movementDirection = movementDirection;
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = movementDirection * velocity;
    }
}
