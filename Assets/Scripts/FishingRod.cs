using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour,IPickable
{
    [SerializeField] GameObject fish;
    [SerializeField] Transform fishHangTransform;

    public void Bal�kTut()
    {
        fish.GetComponent<Animator>().StopPlayback();
        fish.GetComponent<Animator>().enabled = false;
        fish.transform.parent = fishHangTransform;
        fish.transform.localPosition = Vector3.zero;
    }

    public void PerformPickAction()
    {

    }
}
