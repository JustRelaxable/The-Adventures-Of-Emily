using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomuzRock : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IAttackable attackable;
        if(collision.gameObject.TryGetComponent<IAttackable>(out attackable))
        {
            attackable.PerformAttackResult();
        }
    }
}
