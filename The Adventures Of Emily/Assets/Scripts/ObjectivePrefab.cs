using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivePrefab : MonoBehaviour
{
    [SerializeField] Text objectiveText;
    [SerializeField] Image tickImage;
    private Objective objective;

    public void LoadObjective(Objective objective)
    {
        this.objective = objective;
    }

    public void UpdateUI()
    {
        objectiveText.text = objective.ObjectiveText;
        if (objective.ObjectiveCompleted)
        {
            tickImage.gameObject.SetActive(true);
        }
    }
}
