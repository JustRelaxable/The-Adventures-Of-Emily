using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    public RailNode currentNode;
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        StartCoroutine(StartTrain());
    }

    IEnumerator StartTrain()
    {
        for (int i = 0; i < currentNode.points.Length; i++)
        {
            if(i+1<currentNode.points.Length)
                yield return MoveTrain(currentNode.points[i], currentNode.points[i + 1], currentNode.speedOnRail);
            else if(currentNode.nextNode != null)
                yield return MoveTrain(currentNode.points[i], currentNode.nextNode.points[0], currentNode.speedOnRail);
        }

        currentNode = currentNode.nextNode;
        if (currentNode == null)
            yield break;
        yield return StartTrain();
    }

    IEnumerator MoveTrain(Transform start,Transform end,float speed)
    {
        float time = 0;
        float duration = 3;
        
        while (Vector3.Distance(end.position,transform.position) > Time.fixedDeltaTime * speed)
        {
            //rigidbody.MovePosition(Vector3.Lerp(start.position, end.position, (time / duration)));
            rigidbody.MovePosition(Vector3.MoveTowards(transform.position, end.position, Time.fixedDeltaTime*speed));
            rigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, end.rotation, Time.fixedDeltaTime*speed*30));
            //time += Time.deltaTime;
            yield return null;
        }
    }
}
