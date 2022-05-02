using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public string objectName;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EmilyAnimator emilyAnimator = other.GetComponentInChildren<EmilyAnimator>();
            emilyAnimator.TargetGameObject = this.gameObject;
            emilyAnimator.SetBool("Pickable", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EmilyAnimator emilyAnimator = other.GetComponentInChildren<EmilyAnimator>();
            emilyAnimator.TargetGameObject = null;
            emilyAnimator.SetBool("Pickable", false);
        }
    }
}
