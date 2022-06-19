using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPanelUI : MonoBehaviour
{
    [SerializeField] GameObject[] healthIcons;
    private EmilyHealthController emilyHealthController;
    private int lastHealthIconIndex;
    private void Awake()
    {
        emilyHealthController = FindObjectOfType<EmilyHealthController>();
        emilyHealthController.OnEmilyDamaged += EmilyHealthController_OnEmilyDamaged;
        lastHealthIconIndex = healthIcons.Length - 1;
    }

    private void EmilyHealthController_OnEmilyDamaged(int damagePoint)
    {
        for (int i = 0; i < damagePoint; i++)
        {
            if (lastHealthIconIndex < 0)
                return;
            healthIcons[lastHealthIconIndex].SetActive(false);
            lastHealthIconIndex--;
        }
    }
}
