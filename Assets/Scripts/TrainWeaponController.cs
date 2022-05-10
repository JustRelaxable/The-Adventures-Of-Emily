using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainWeaponController : MonoBehaviour
{
    [SerializeField] Transform rotationPivot,barrel;
    [SerializeField] Transform trainCamera;
    [SerializeField] float rotationVelocity;
    [SerializeField] GameObject projectile;
    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, trainCamera.rotation, Time.deltaTime*rotationVelocity);
        if (Input.GetMouseButtonDown(0))
        {
            var p = Instantiate(projectile);
            p.transform.position = barrel.transform.position;
            p.transform.rotation = barrel.transform.rotation;
            p.GetComponent<Rigidbody>().AddForce(barrel.transform.forward * 1000);
        }
    }
}
