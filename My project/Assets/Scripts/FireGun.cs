using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))//Input Get leftMouse Push
            Instantiate(projectile,firePoint.transform.position,firePoint.transform.rotation);
    }
}
