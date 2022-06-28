using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kurek : MonoBehaviour, IPickable
{
    [SerializeField] int digCount = 3;
    [SerializeField] GameObject[] digObjects;
    private GameObject emily;
    private EmilyAnimator emilyAnimator;
    public void PerformPickAction()
    {
        emily = GameObject.FindGameObjectWithTag("Player");
        emilyAnimator = emily.GetComponentInChildren<EmilyAnimator>();
        //emily.GetComponentInChildren<EmilyAnimator>().isDig = true;
        emily.GetComponent<ThirdPersonInput>().AttackPressed += Kurek_AttackPressed;
    }

    private void Kurek_AttackPressed()
    {
        digCount--;
        Destroy(digObjects[digCount].gameObject);
        emilyAnimator.SetTrigger("Dig");
        if (digCount == 0)
        {
            emily.GetComponentInChildren<EmilyObjectHoldController>().ReleaseObject();
            //emily.GetComponentInChildren<EmilyAnimator>().isDig = false;
        }
    }
}
