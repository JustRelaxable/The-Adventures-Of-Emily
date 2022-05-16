using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeButton : MonoBehaviour
{
    [SerializeField] GameObject requiredGameObject;
    [SerializeField] GameObject bridge;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EmilyObjectHoldController emilyObjectHoldController = other.gameObject.GetComponentInChildren<EmilyObjectHoldController>();
            if (emilyObjectHoldController.GetPickableObject() == requiredGameObject)
            {
                bridge.gameObject.SetActive(true);
            }
        }
    }
}
