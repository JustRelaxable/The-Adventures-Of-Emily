using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FishingRod fishingRod;
            if (other.GetComponentInChildren<EmilyObjectHoldController>().GetPickableObject().TryGetComponent<FishingRod>(out fishingRod))
                other.GetComponentInChildren<EmilyAnimator>().SetBool("Fishable", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInChildren<EmilyAnimator>().SetBool("Fishable", false);
        }
    }
}
