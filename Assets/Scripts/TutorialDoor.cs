using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDoor : MonoBehaviour
{
    [SerializeField] ObjectiveUI objectiveUI;
    [SerializeField] Animator doorAnimator;
    [SerializeField] TutorialKey tutorialKey;
    [SerializeField] GameObject questionMark3;
    


    private Objective objective;
    public AudioClip doorsound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInChildren<EmilyAnimator>().EmilyAttackEnabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        /*
        if (objective == null && Input.GetMouseButtonDown(0))
        {
            questionMark3.gameObject.SetActive(true);
            objective = new Objective("Find the key of the door.", false);
            tutorialKey.keyObjective = objective;
            objectiveUI.AddObjective(objective);
            objectiveUI.UpdateUI();
        }

        if (objective!=null&& objective.ObjectiveCompleted && Input.GetMouseButtonDown(0))
        {
            doorAnimator.SetTrigger("OpenDoor");
        }*/

        if(tutorialKey.KeyCollected && Input.GetKeyDown(KeyCode.E))
        {
            doorAnimator.SetTrigger("OpenDoor");
            AudioSource.PlayClipAtPoint(doorsound, transform.position);
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
