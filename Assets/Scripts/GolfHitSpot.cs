using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfHitSpot : MonoBehaviour
{
    [SerializeField] GameObject animationObject;
    public bool isAnimationPlaying = false;
    GameObject emilyGameObject;
    Animator animationObjectAnimator;
    private void Awake()
    {
        animationObjectAnimator = animationObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            emilyGameObject = other.gameObject;
            animationObjectAnimator.SetTrigger("Hit");
            isAnimationPlaying = true;
        }
    }

    private void LateUpdate()
    {
        if (isAnimationPlaying)
        {
            emilyGameObject.transform.position = animationObject.transform.position;
        }
    }
}
