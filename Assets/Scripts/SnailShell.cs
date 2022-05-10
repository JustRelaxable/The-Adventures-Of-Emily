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

    public void PerformPickAction()
    {
        meshCollider.enabled = false;
        sphereCollider.enabled = false;
        rigidbody.isKinematic = true;
        rigidbody.useGravity = false;
        transform.localScale = new Vector3(30, 30, 30);
    }
}
