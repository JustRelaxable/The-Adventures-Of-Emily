using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutCrackerSword : MonoBehaviour
{
    public bool CanHit { get => canHit; set=>canHit = value; }
    private bool canHit = false;
    private void OnTriggerEnter(Collider other)
    {
        IAttackable attackable;
        if(canHit && other.TryGetComponent<IAttackable>(out attackable))
        {
            attackable.PerformAttackResult();
        }
    }
}
