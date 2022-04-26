using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OltaPickableObject : PickableObject
{
    [SerializeField] GameObject fish;

    public void Bal�kTut()
    {
        fish.GetComponent<Animator>().enabled = false;
        fish.transform.parent = transform;
        fish.transform.position = transform.position;
    }
}
