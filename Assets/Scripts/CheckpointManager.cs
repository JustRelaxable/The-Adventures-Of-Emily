using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;
    public Checkpoint lastCheckpoint;
    public GameObject character;

    public void SetLastCheckpoint(Checkpoint checkpoint)
    {
        lastCheckpoint = checkpoint;
    }

    private void Awake()
    {
        instance = this;
    }

    public void GoToLastCheckpoint()
    {
        character.transform.position = lastCheckpoint.transform.position;
    }
}
