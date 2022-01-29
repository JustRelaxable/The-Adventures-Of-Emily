using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveUI : MonoBehaviour
{
    public Stack<Objective> objectives = new Stack<Objective>();

    public void AddObjective(Objective objective)
    {
        objectives.Push(objective);
    }

    public void AddObjective(string text,bool isCompleted)
    {
        objectives.Push(new Objective(text, isCompleted));
    }

    public void UpdateUI()
    {

    }
}
