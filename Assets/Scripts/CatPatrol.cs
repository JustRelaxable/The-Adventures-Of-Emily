using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatPatrol : MonoBehaviour
{
    public float catSpeed;
    public GameObject character;
    public GameObject catRestPoint;
    private Coroutine currentCoroutine;
    private NavMeshAgent navMeshAgent;
    private Action followAction;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    private void Start()
    {
        //navMeshAgent.SetDestination(character.transform.position);
    }

    private void Update()
    {
        followAction?.Invoke();
    }

    public void GoToCharacter()
    {/*
        if(currentCoroutine!=null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(GoTo(character.transform));
        */
        followAction += () => navMeshAgent.SetDestination(character.transform.position);
    }

    public void GoToRest()
    {
        /*
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(GoTo(catRestPoint.transform));
        */
        followAction = () => { };
        navMeshAgent.SetDestination(catRestPoint.transform.position);
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
            other.GetComponent<EmilyHealthController>().DealDamageToEmily(1);
            CheckpointManager.instance.GoToLastCheckpoint();
            GoToRest();
        }
    }
}
