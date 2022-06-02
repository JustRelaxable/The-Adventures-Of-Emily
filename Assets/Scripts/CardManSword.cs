using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManSword : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IAttackable attackable;
        bool isPlayer = other.CompareTag("Player");
        if (isPlayer && other.TryGetComponent<IAttackable>(out attackable))
        {
            attackable.PerformAttackResult();
        }
    }
}
