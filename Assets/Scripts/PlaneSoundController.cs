using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSoundController : MonoBehaviour
{
    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOneShotSound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

}
