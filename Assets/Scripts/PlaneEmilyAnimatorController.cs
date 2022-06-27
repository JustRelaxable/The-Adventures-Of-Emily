using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneEmilyAnimatorController : MonoBehaviour
{
    [SerializeField] Animator planeEmilyAnimator;
    public void SitEmily()
    {
        planeEmilyAnimator.SetTrigger("Sit");
    }
}
