using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainBall : MonoBehaviour
{
    public GameObject explosion;
    public GameObject spawnPoint;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile") || collision.gameObject.CompareTag("Train"))
        {
            Instantiate(explosion).transform.position = spawnPoint.transform.position;
            Destroy(this.gameObject);
        }
    }
}
