using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPatrol : MonoBehaviour
{
    public float catSpeed;
    public GameObject character;
    public GameObject catRestPoint;
    private Coroutine currentCoroutine;

    private void Start()
    {
    }

    public void GoToCharacter()
    {
        if(currentCoroutine!=null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(GoTo(character.transform));
    }

    public void GoToRest()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(GoTo(catRestPoint.transform));
    }

    IEnumerator GoTo(Transform t)
    {
        while((t.position).magnitude > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, t.position, catSpeed * Time.deltaTime);
            transform.LookAt(t.position);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointManager.instance.GoToLastCheckpoint();
            GoToRest();
        }
    }
}
