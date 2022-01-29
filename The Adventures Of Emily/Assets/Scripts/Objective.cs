using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Objective
{
    [SerializeField] string objectiveText;
    [SerializeField] bool isObjectiveCompleted;
    public string ObjectiveText { get => objectiveText; set => objectiveText = value; }
    public bool ObjectiveCompleted { get => isObjectiveCompleted; set => isObjectiveCompleted = value; }
    public List<Objective> SubObjectives { get; set; }

    public Objective(string text, bool isCompleted)
    {
        ObjectiveText = text;
        ObjectiveCompleted = isCompleted;
        SubObjectives = new List<Objective>();
    }
}
