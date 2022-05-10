using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.GetComponentInChildren<EmilyObjectHoldController>().GetNameOfCurrentObject() == "Olta")
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
