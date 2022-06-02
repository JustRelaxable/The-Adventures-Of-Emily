using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMan : MonoBehaviour,IAttackable
{
    public float radius;
    public float speed;
    public float attackRadius;
    [SerializeField] int hitPoints;
    private Animator animator;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PerformAttackResult()
    {
        hitPoints--;
        if (hitPoints > 0)
            animator.SetTrigger("Hit");
        else
            animator.SetTrigger("Death");
    }
}
