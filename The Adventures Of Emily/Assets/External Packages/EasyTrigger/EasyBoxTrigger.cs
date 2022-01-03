using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class EasyBoxTrigger : CollisionBasedTrigger
{
    void OnTriggerEnter(Collider other)
    {
        CheckForTrigger(enterEvents, other);
    }

    void OnTriggerExit(Collider other)
    {
        CheckForTrigger(exitEvents, other);
    }

    void CheckForTrigger(UnityEvent events, Collider other)
    {
        if (supportMultiTag)
        {
            foreach (var currentOtherTag in tags)
            {
                if (other.CompareTag(currentOtherTag))
                {
                    events?.Invoke();
                }
            }
        }
        else
        {
            if (other.CompareTag(otherTag))
            {
                events?.Invoke();
            }
        }
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        var col = GetComponent<BoxCollider>();
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = triggerBoxColor;
        Gizmos.DrawCube(col.center + Vector3.zero, col.size);
    }
#endif
    
}
