using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceZone : MonoBehaviour
{
    ThirdPersonMovement emilyMovement;
    private void Awake()
    {
        emilyMovement = FindObjectOfType<ThirdPersonMovement>();        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            emilyMovement.OnEnterIce();
            emilyMovement.onIce = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            emilyMovement.onIce = false;
        }
    }
}
