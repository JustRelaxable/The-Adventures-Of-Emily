using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSliderUI : MonoBehaviour
{
    [SerializeField] Component targetHitPointsComponent;
    IHitPoints targetHitPointsInterface;
    private Slider healthSlider;
    private bool destroyFunctionCalled = false;

    private void Awake()
    {
        targetHitPointsInterface = targetHitPointsComponent.GetComponent<IHitPoints>();
        healthSlider = GetComponent<Slider>();
        healthSlider.maxValue = targetHitPointsInterface.HitPoints;
        healthSlider.minValue = 0;
    }

    private void LateUpdate()
    {
        healthSlider.value = targetHitPointsInterface.HitPoints;
        if(targetHitPointsInterface.HitPoints == 0 && !destroyFunctionCalled)
        {
            Destroy(this.gameObject, 3f);
            destroyFunctionCalled = true;
        }
    }
}
