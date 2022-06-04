using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialQuestionMarks : MonoBehaviour
{
    [SerializeField] string tutorialText;
    private TutorialTextPanel tutorialTextPanel;
    private void Awake()
    {
        tutorialTextPanel = FindObjectOfType<TutorialTextPanel>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tutorialTextPanel.SetText(tutorialText);
            tutorialTextPanel.OpenPanel();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tutorialTextPanel.ClosePanel();
        }
        
    }
}
