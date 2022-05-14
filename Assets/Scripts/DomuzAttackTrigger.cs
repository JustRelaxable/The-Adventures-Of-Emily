using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomuzAttackTrigger : MonoBehaviour
{
    [SerializeField] Domuz domuz;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            domuz.EmilyEnteredWarZone();
        }
    }
}
