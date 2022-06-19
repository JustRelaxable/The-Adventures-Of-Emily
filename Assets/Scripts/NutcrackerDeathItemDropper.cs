using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutcrackerDeathItemDropper : MonoBehaviour
{
    [SerializeField] GameObject itemToDrop;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.GetBehaviour<NutCrackerDeathBehaviour>().OnNutcrackerDeath += NutcrackerDeathItemDropper_OnNutcrackerDeath;
    }

    private void NutcrackerDeathItemDropper_OnNutcrackerDeath()
    {
        Vector3 instantiatePosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z+1);
        Instantiate(itemToDrop, instantiatePosition, Quaternion.identity).SetActive(true);
    }
}
