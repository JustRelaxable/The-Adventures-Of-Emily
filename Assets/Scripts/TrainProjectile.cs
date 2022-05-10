using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainProjectile : MonoBehaviour
{
    Rigidbody rigidbody;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
    }
}
