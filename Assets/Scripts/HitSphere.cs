using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSphere : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInChildren<EmilyAnimator>().Hit();
            other.GetComponent<ThirdPersonMovement>().Hit();
        }
    }
}
