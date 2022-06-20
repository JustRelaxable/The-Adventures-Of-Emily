using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EmilyHealthController emilyHealthController;
            emilyHealthController = collision.gameObject.GetComponent<EmilyHealthController>();
            emilyHealthController.DealDamageToEmily(1);
            CheckpointManager.instance.GoToLastCheckpoint();
        }
    }
}
