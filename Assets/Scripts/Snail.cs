using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour, IAttackable
{
    [SerializeField] private int hitPoints;
    [SerializeField] private SnailShell snailShell;
    public void PerformAttackResult()
    {
        hitPoints--;
        if (hitPoints == 0)
        {
            snailShell.DropTheShell();
        }
    }
}
