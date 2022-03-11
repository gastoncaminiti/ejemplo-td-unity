using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform weapon;
    [SerializeField] private Transform target;

    [SerializeField] private float rangeWeapon = 15f;

    [SerializeField] private ParticleSystem weaponMunition;

    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    private void FindClosestTarget()
    {
        Enemy[] enemys = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;
        foreach (Enemy enemy in enemys)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }

    private void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);
        if (targetDistance < rangeWeapon)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }

    }

    void Attack(bool isActive)
    {
        ParticleSystem.EmissionModule munition = weaponMunition.emission;
        munition.enabled = isActive;
    }
}
