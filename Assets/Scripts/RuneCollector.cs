using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneCollector : MonoBehaviour
{
    [SerializeField] int runeCount;
    [SerializeField] Animator doorRockAnimator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EmilyObjectHoldController emilyObjectHoldController = other.GetComponentInChildren<EmilyObjectHoldController>();
            GameObject runeGameObject = emilyObjectHoldController.GetPickableObject();
            if (runeGameObject == null)
                return;
            runeGameObject.GetComponent<RunePickable>().associatedRuneRock.ActivateRuneRock();
            runeCount--;
            emilyObjectHoldController.ReleaseObject();
            if(runeCount == 0)
            {
                //open door
                doorRockAnimator.SetTrigger("Open");
            }
        }
    }
}
