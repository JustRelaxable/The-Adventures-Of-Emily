using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunePickable : MonoBehaviour,IPickable
{
    [SerializeField] int runeNumber;

    public void PerformPickAction()
    {
        Rigidbody rigidbody;
        if(TryGetComponent<Rigidbody>(out rigidbody))
        {
            Destroy(rigidbody);
        }
    }

    public int GetRuneNumber()
    {
        return runeNumber;
    }
}
