using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneRock : MonoBehaviour
{
    [SerializeField] Material completedRuneRockMaterial;

    public void ActivateRuneRock()
    {
        GetComponent<MeshRenderer>().material = completedRuneRockMaterial;
    }
}
