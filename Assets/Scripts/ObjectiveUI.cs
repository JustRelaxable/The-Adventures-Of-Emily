using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveUI : MonoBehaviour
{
    public List<Objective> objectives = new List<Objective>();
    public GameObject objectivePrefab;

    private void Start()
    {
        UpdateUI();
    }

    public void AddObjective(Objective objective)
    {
        objectives.Add(objective);
    }

    public void AddObjective(string text,bool isCompleted)
    {
        objectives.Add(new Objective(text, isCompleted));
    }

    public void UpdateUI()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < objectives.Count; i++)
        {
            GameObject go = Instantiate(objectivePrefab, transform);
            go.GetComponent<ObjectivePrefab>().LoadObjective(objectives[i]);
            go.GetComponent<ObjectivePrefab>().UpdateUI();
        }
    }
}
