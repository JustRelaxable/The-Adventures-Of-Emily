using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialKey : MonoBehaviour
{
    public Objective keyObjective;
    public bool KeyCollected { get => keyCollected;}
    private bool keyCollected = false;
    public AudioClip keysound;
    [SerializeField] ObjectiveUI objectiveUI;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            keyObjective.ObjectiveCompleted = true;
            keyCollected = true;
            objectiveUI.UpdateUI();
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(keysound, transform.position);
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
