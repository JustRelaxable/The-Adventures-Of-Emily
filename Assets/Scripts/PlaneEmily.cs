using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneEmily : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponentInChildren<Animator>().SetTrigger("Sit");
    }
}
