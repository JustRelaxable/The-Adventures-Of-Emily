using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunePickable : MonoBehaviour,IPickable
{
    [SerializeField] int runeNumber;

    public void PerformPickAction()
    {
    }

    public int GetRuneNumber()
    {
        return runeNumber;
    }
}
