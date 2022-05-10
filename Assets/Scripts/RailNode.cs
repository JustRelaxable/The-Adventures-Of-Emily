using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailNode : MonoBehaviour
{
    public Transform[] points;
    public float speedOnRail;
    public RailNode nextNode;

    private void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
        var index = transform.GetSiblingIndex();
        if(transform.parent.childCount > index+1)
        {
            nextNode = transform.parent.GetChild(index+1).GetComponent<RailNode>();
        }
    }
}
