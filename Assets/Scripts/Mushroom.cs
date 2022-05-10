using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour, IPickable
{
    public void PerformPickAction()
    {
        Vector3 scale = transform.localScale;
        transform.localScale = scale / 3;
    }
}
