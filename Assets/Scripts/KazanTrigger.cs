using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KazanTrigger : MonoBehaviour
{
    [SerializeField] Transform objectsHolder;
    [SerializeField] GameObject iksir;
    [SerializeField] GameObject mantar;
    [SerializeField] GameObject balýk;
    [SerializeField] GameObject snailShell;
    [SerializeField] GameObject kemik;
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
                GameObject targetKazanObject = pickableObject.GetComponent<KazanPickable>().targetKazanObject;
                IncreaseAlpha(targetKazanObject);
                emilyObjectHoldController.ReleaseObject();
                /*
                pickableObject.transform.parent = objectPoints[objectIndex];
                Debug.Log(objectIndex);
                objectIndex++;
                pickableObject.transform.localPosition = Vector3.zero;

                */
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
