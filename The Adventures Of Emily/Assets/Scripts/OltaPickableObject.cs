using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OltaPickableObject : PickableObject
{
    [SerializeField] GameObject fish;
    [SerializeField] Transform fishHangTransform;

    public void BalýkTut()
    {
        fish.GetComponent<Animator>().StopPlayback();
        fish.GetComponent<Animator>().enabled = false;
        fish.transform.parent = fishHangTransform;
        fish.transform.localPosition = Vector3.zero;
    }
}
