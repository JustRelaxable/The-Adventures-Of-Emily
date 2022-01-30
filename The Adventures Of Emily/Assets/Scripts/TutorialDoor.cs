using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDoor : MonoBehaviour
{
    [SerializeField] ObjectiveUI objectiveUI;
    [SerializeField] Animator doorAnimator;
    [SerializeField] TutorialKey tutorialKey;
    private Objective objective;
    private void OnTriggerEnter(Collider other)
    {
        if(objective == null)
        {
            objective = new Objective("Find the key of the door.", false);
            tutorialKey.keyObjective = objective;
            objectiveUI.AddObjective(objective);
            objectiveUI.UpdateUI();
        }

        if (objective.ObjectiveCompleted)
        {
            doorAnimator.SetTrigger("OpenDoor");
        }
    }
}
