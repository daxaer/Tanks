using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform muzzle;

    public void Fireprojectile(int power)
    {
        GameObject insProj = Instantiate(projectilePrefab, muzzle.transform.position, muzzle.transform.rotation);
        insProj.GetComponent<Proyectile>().Initialize(power);
    }
}
