using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingRock : MonoBehaviour
{
    [SerializeField] float speed;
    private float currentLevel;
    private bool isPlayerInside = false;

    private void Update()
    {
        if(currentLevel<0 && !isPlayerInside)
        {
            currentLevel += speed * Time.deltaTime;
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentLevel -= speed * Time.deltaTime;
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }
}
