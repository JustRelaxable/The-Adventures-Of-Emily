using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDamageableWater : MonoBehaviour
{
    [SerializeField] Transform teleportTransform;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EmilyHealthController emilyHealthController = other.GetComponent<EmilyHealthController>();
            emilyHealthController.DealDamageToEmily(1);
            if(emilyHealthController.GetCurrentHealth() <= 0)
            {
                //Don'T teleport
            }
            else
            {
                other.gameObject.transform.position = teleportTransform.position;
            }
        }
    }
}
