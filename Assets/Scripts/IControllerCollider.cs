using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllerCollider
{
    public void CalculateCollision(ControllerColliderHit hit,EmilyTriggerController emilyTriggerController);
}
