using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopSpawner : MonoBehaviour
{
    public GameObject top;

    private void Start()
    {
        StartCoroutine(SpawnTop());
    }

    IEnumerator SpawnTop()
    {
        float duration = Random.Range(3f,10f);
        float time = 0f;

        while (true)
        {
            time += Time.deltaTime;
            if (time > duration)
            {
                var top = Spawn();
                top.transform.position = transform.position;
                top.GetComponent<Rigidbody>().AddForce(Vector3.right * Random.Range(200f,350f));
                Destroy(top, 10);
                time = 0f;
                duration = Random.Range(3f, 10f);
            }
            yield return null;
        }
    }

    private GameObject Spawn()
    {
        return Instantiate(top);
    }
}
