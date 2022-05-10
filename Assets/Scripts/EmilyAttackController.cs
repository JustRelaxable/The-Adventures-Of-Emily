using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmilyAttackController : MonoBehaviour
{
    [SerializeField] private GameObject tornado;
    [SerializeField] private float tornadoSpawnPointForward;
    public void Attack()
    {
        Vector3 tornadoSpawnPoint = transform.position + transform.forward * tornadoSpawnPointForward;
        GameObject spawnedTornado = Instantiate(tornado);
        spawnedTornado.transform.position = tornadoSpawnPoint;
        spawnedTornado.GetComponent<TornadoMovement>().InitializeMovementDirection(transform.forward);
    }
}
