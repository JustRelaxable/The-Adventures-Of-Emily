using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Domuz : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
    }

    public void EmilyEnteredWarZone()
    {
        animator.SetTrigger("EmilyEnteredWarZone");
    }
}
