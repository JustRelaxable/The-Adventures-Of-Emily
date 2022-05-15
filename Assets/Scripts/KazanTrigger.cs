using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KazanTrigger : MonoBehaviour
{
    [SerializeField] Transform objectsHolder;
    private Transform[] objectPoints;
    private int objectIndex;
    private void Awake()
    {
        objectPoints = new Transform[objectsHolder.childCount];
        for (int i = 0; i < objectsHolder.childCount; i++)
        {
            objectPoints[i] = objectsHolder.GetChild(i);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EmilyAnimator emilyAnimator = other.gameObject.GetComponentInChildren<EmilyAnimator>();
            EmilyObjectHoldController emilyObjectHoldController = other.gameObject.GetComponentInChildren<EmilyObjectHoldController>();
            if (emilyAnimator.TargetGameObject != null)
            {
                GameObject pickableObject = emilyObjectHoldController.GetPickableObject();
                pickableObject.transform.parent = objectPoints[objectIndex];
                objectIndex++;
                pickableObject.transform.localPosition = Vector3.zero;
                emilyObjectHoldController.ReleaseObject();
            }
        }
    }
}
