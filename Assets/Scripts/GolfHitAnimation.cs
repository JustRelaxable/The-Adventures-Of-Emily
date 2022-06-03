using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfHitAnimation : MonoBehaviour
{
    [SerializeField] GolfHitSpot golfHitSpot;

    public void DisableFollow()
    {
        golfHitSpot.isAnimationPlaying = false;
    }
}
