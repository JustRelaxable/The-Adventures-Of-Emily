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
    private void OnTriggerEnter(Collider other)
    {
   

       
    }

    private void OnTriggerStay(Collider other)
    {
        if (objective == null && Input.GetKeyDown(KeyCode.E))
        {
            questionMark3.gameObject.SetActive(true);
            objective = new Objective("Find the key of the door.", false);
            tutorialKey.keyObjective = objective;
            objectiveUI.AddObjective(objective);
            objectiveUI.UpdateUI();
        }

        if (objective!=null&& objective.ObjectiveCompleted && Input.GetKeyDown(KeyCode.E))
        {
            doorAnimator.SetTrigger("OpenDoor");
        }
    }
}
