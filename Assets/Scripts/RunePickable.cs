using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunePickable : MonoBehaviour,IPickable
{
    public RuneRock associatedRuneRock;

    public void PerformPickAction()
    {
        Rigidbody rigidbody;
        if(TryGetComponent<Rigidbody>(out rigidbody))
        {
            Destroy(rigidbody);
        }
    }
}
