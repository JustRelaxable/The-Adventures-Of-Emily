using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KazanTrigger : MonoBehaviour
{
    [SerializeField] int pickableCount = 6;
    [SerializeField] GameObject finalPotion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EmilyAnimator emilyAnimator = other.gameObject.GetComponentInChildren<EmilyAnimator>();
            EmilyObjectHoldController emilyObjectHoldController = other.gameObject.GetComponentInChildren<EmilyObjectHoldController>();
            if (emilyAnimator.TargetGameObject != null)
            {
                GameObject pickableObject = emilyObjectHoldController.GetPickableObject();
                GameObject targetKazanObject = pickableObject.GetComponent<KazanPickable>().targetKazanObject;
                IncreaseAlpha(targetKazanObject);
                emilyObjectHoldController.ReleaseObject();
                pickableCount--;
                if(pickableCount == 0)
                {
                    finalPotion.SetActive(true);
                }
            }
        }
    }

    private void IncreaseAlpha(GameObject target)
    {
        MeshRenderer[] meshRenderers = target.GetComponentsInChildren<MeshRenderer>();
        foreach (var renderer in meshRenderers)
        {
            foreach (var material in renderer.materials)
            {
                Color color = material.GetColor("_BaseColor");
                color.a = 1;
                material.SetColor("_BaseColor", color);
            }
        }

        SkinnedMeshRenderer[] skinnedMeshRenderers = target.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (var renderer in skinnedMeshRenderers)
        {
            foreach (var material in renderer.materials)
            {
                Color color = material.GetColor("_BaseColor");
                color.a = 1;
                material.SetColor("_BaseColor", color);
            }
        }
    }
}
