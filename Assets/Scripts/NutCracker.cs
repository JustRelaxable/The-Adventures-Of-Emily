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
        animator.SetTrigger("HitTaken");
    }

    public void EnableNutCrackerSwordHit()
    {
        NutCrackerSword.CanHit = true;
    }
}
