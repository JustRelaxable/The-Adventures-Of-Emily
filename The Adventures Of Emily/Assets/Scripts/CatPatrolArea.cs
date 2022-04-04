using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPatrolArea : MonoBehaviour
{
    public CatPatrol catPatrol;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            catPatrol.GoToCharacter();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            catPatrol.GoToRest();
        }
    }
}
