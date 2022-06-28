using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomuzEt : MonoBehaviour, IPickable
{
    public void PerformPickAction()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        transform.localScale = transform.localScale / 2;
    }
}
