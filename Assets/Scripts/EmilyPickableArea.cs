using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmilyPickableArea : MonoBehaviour
{
    [SerializeField] private EmilyAnimator emilyAnimator;
    [SerializeField] private EmilyObjectHoldController emilyObjectHoldController;
    private void OnTriggerStay(Collider other)
    {
        IPickable pickable;
        if(other.TryGetComponent<IPickable>(out pickable) && emilyObjectHoldController.GetPickableObject() == null)
        {
            emilyAnimator.TargetGameObject = other.gameObject;
            emilyAnimator.SetBool("Pickable", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IPickable pickable;
        if (other.TryGetComponent<IPickable>(out pickable))
        {
            emilyAnimator.TargetGameObject = null;
            emilyAnimator.SetBool("Pickable", false);
        }
    }
}
