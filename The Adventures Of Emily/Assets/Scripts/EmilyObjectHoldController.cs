using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmilyObjectHoldController : MonoBehaviour
{
    [SerializeField] Transform holdTransform;
    [SerializeField] SkinnedMeshRenderer yast�kRenderer;

    private PickableObject pickableObject;

    public PickableObject GetPickableObject()
    {
        return pickableObject;
    }

    public string GetNameOfCurrentObject()
    {
        if (holdTransform.childCount > 0)
        {
            return holdTransform.GetChild(0).gameObject.GetComponent<PickableObject>().objectName;
        }
        else
        {
            return null;
        }
    }

    public void HoldObject(GameObject pickableObject)
    {
        this.pickableObject = pickableObject.GetComponent<PickableObject>();
        pickableObject.transform.parent = holdTransform;
        pickableObject.transform.localPosition = Vector3.zero;
        pickableObject.transform.localRotation = Quaternion.identity;
        yast�kRenderer.enabled = false;
    }

    public void ReleaseObject()
    {
        if (holdTransform.childCount > 0)
        {
            Destroy(holdTransform.GetChild(0).gameObject);
            yast�kRenderer.enabled = true;
        }
    }
}