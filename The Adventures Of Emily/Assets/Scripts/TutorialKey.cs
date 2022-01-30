using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialKey : MonoBehaviour
{
    public Objective keyObjective;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            keyObjective.ObjectiveCompleted = true;
            Destroy(this.gameObject);
        }
    }
}
