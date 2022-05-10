using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmilyPickableArea : MonoBehaviour
{
    [SerializeField] private EmilyAnimator emilyAnimator;
    private void OnTriggerStay(Collider other)
    {
        IPickable pickable;
        if(other.TryGetComponent<IPickable>(out pickable))
        {
            emilyAnimator.TargetGameObject = other.gameObject;
            emilyAnimator.SetBool("Pickable", true);
        }
    }
}
