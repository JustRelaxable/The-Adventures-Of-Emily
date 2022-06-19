using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmilyHealthController : MonoBehaviour
{
    [SerializeField] int emilyDamagePoint = 4;
    public event Action<int> OnEmilyDamaged;

    public void DealDamageToEmily(int damagePoint)
    {
        OnEmilyDamaged?.Invoke(damagePoint);
        emilyDamagePoint -= damagePoint;
        if(emilyDamagePoint <= 0)
        {
            //Game Over - Level restart
        }
    }

    public int GetCurrentHealth()
    {
        return emilyDamagePoint;
    }
}
