using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piyano : MonoBehaviour
{
    [SerializeField] int[] noteSequence;
    [SerializeField] AudioClip wrongNote;
    [SerializeField] AudioClip[] noteClipSequence;
    private int nextNoteIndex;
    private AudioSource audioSource;
    private Animator animator;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    public void PlayOneShot(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void PiyanoWrongNotePressed()
    {
        ResetNote();
        audioSource.PlayOneShot(wrongNote);
    }

    public void PiyanoCorrectNotePressed()
    {
        audioSource.PlayOneShot(noteClipSequence[nextNoteIndex-1]);
    }

    public int GetNextNote()
    {
        int temp = noteSequence[nextNoteIndex];
        if(nextNoteIndex == noteSequence.Length - 1)
        {
            animator.SetTrigger("SequenceCompleted");
        }
        nextNoteIndex++;
        return temp;
    }

    public void ResetNote()
    {
        nextNoteIndex = 0;
    }
}
