using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiyanoTush : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] int tushNumber;

    private Piyano piyano;
    private bool pushed = false;

    private void Awake()
    {
        piyano = transform.parent.GetComponent<Piyano>();
    }

    private void OnTriggerEnter(Collider other)
    {
  
        if (other.tag == "Player")
        {
            pushed = true;
            animator.SetTrigger("Pushed");
            OnTushStepped();
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            pushed = false;
            animator.SetTrigger("NotPushed");
        }
    }

    private void OnTushStepped()
    {
        if(piyano.GetNextNote() == tushNumber)
        {
            piyano.PiyanoCorrectNotePressed();
        }
        else
        {
            piyano.PiyanoWrongNotePressed();
        }
    }
}
