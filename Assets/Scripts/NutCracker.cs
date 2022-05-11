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
    private NavMeshAgent navMeshAgent;
    private GameObject target;
    private Animator animator;

    private bool followingTarget = false;
    private bool swordAttackInProgress = false;

    private Action FollowAction;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
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
