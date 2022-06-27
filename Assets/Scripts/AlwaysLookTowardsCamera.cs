using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysLookTowardsCamera : MonoBehaviour
{
    [SerializeField] bool inverse;

    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform,inverse ? -Vector3.up : Vector3.up);
    }
}
