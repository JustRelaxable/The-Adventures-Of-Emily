using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour
{
    public int completedObjectiveIndex;
    public string newObjective;
    public ObjectiveUI objectiveUI;

    public void UpdateObjective()
    {
        objectiveUI.objectives[completedObjectiveIndex].ObjectiveCompleted = true;
        objectiveUI.AddObjective(new Objective(newObjective, false));
        objectiveUI.UpdateUI();
    }
}
