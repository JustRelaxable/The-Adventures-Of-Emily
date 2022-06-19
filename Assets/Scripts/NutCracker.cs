using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NutCracker : MonoBehaviour,IAttackable
{
    public float EmilyTargetRadius { get => emilyTargetRadius; }
    public float AttackDistance { get=>attackDistance; }
    public NutCrackerSword NutCrackerSword { get => nutCrackerSword; }

    [SerializeField] int attackPoint;
    [SerializeField] float attackDistance;
    [SerializeField] float emilyTargetRadius;
    [SerializeField] NutCrackerSword nutCrackerSword;
    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PerformAttackResult()
    {
        attackPoint--;
        if (attackPoint <= 0)
        {
            animator.SetTrigger("Death");
        }
        else
        {
            animator.SetTrigger("HitTaken");
        }

    }

    public void EnableNutCrackerSwordHit()
    {
        NutCrackerSword.CanHit = true;
    }

    public void GetDamage()
    {
     
    }
}
