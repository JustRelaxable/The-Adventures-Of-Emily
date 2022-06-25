using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWalk : MonoBehaviour
{
    public AudioClip waterwalk;
    private Objective objective;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                //
                AudioSource.PlayClipAtPoint(waterwalk, transform.position);
            }
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
        }
    }
}