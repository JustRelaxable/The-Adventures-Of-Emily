using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastRailNode : MonoBehaviour
{
    public GameObject character;
    public GameObject spawnPoint;

    public void TeleportCharacter()
    {
        character.transform.SetPositionAndRotation(spawnPoint.transform.position, Quaternion.identity);
    }
}
