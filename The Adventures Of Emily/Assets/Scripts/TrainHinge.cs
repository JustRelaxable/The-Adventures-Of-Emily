using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainHinge : MonoBehaviour
{
    public Rigidbody frontNode;
    public Transform hingeFollow;
    private Transform frontNodeTransform;

    private void Awake()
    {
        frontNodeTransform = frontNode.transform;
    }

    private void Update()
    {
        transform.position = hingeFollow.transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, frontNodeTransform.rotation, Time.deltaTime * frontNode.velocity.magnitude /2);
    }
}
