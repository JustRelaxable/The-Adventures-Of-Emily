using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainBall : MonoBehaviour
{
    public GameObject explosion;
    public GameObject spawnPoint;
    public AudioClip clip;
    private AudioSource audioSource;
    private SphereCollider sphereCollider;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        sphereCollider = GetComponent<SphereCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile") || collision.gameObject.CompareTag("Train"))
        {
            Instantiate(explosion).transform.position = spawnPoint.transform.position;
            //Destroy(this.gameObject);
            sphereCollider.enabled = false;
            meshRenderer.enabled = false;
            audioSource.PlayOneShot(clip);
        }
    }
}
