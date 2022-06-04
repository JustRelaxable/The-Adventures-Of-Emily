using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialKey : MonoBehaviour
{
    public Objective keyObjective;
    [SerializeField] ObjectiveUI objectiveUI;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0))
        {
            keyObjective.ObjectiveCompleted = true;
            objectiveUI.UpdateUI();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInChildren<EmilyAnimator>().EmilyAttackEnabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInChildren<EmilyAnimator>().EmilyAttackEnabled = true;
        }
    }
}
