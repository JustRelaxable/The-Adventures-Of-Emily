using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailShell : MonoBehaviour,IPickable
{
    [SerializeField] private MeshCollider meshCollider;
    [SerializeField] private SphereCollider sphereCollider;
    [SerializeField] private Rigidbody rigidbody;

    public void DropTheShell()
    {
        meshCollider.enabled = true;
        sphereCollider.enabled = true;
        rigidbody.useGravity = true;
        transform.parent = null;
    }
}
