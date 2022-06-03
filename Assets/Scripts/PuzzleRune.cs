using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRune : MonoBehaviour
{
    GameObject[] gameObjectsToDisable;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var item in gameObjectsToDisable)
            {
                item.SetActive(false);
                animator.SetTrigger("Pressed");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("Released");
        }
    }
}
