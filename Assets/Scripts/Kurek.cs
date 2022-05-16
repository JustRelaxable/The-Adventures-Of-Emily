using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kurek : MonoBehaviour, IPickable
{
    [SerializeField] int digCount = 3;
    [SerializeField] GameObject[] digObjects;
    private GameObject emily;
    public void PerformPickAction()
    {
        emily = GameObject.FindGameObjectWithTag("Player");
        emily.GetComponentInChildren<EmilyAnimator>().isDig = true;
        emily.GetComponent<ThirdPersonInput>().AttackPressed += Kurek_AttackPressed;
    }

    private void Kurek_AttackPressed()
    {
        digCount--;
        Destroy(digObjects[digCount].gameObject);
        if (digCount == 0)
        {
            emily.GetComponentInChildren<EmilyObjectHoldController>().ReleaseObject();
            emily.GetComponentInChildren<EmilyAnimator>().isDig = false;
        }
    }
}
