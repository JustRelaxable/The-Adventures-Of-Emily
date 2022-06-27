using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalIsland : MonoBehaviour
{
    [SerializeField] Animator doorAnimator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinalPotion"))
        {
            doorAnimator.SetTrigger("EmilyHasPotion");
        }
    }
}
