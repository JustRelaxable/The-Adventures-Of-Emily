using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balık : MonoBehaviour, IPickable
{
    public void PerformPickAction()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
    }
}
