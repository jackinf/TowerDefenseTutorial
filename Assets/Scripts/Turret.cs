using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    
    [Header("General")]
    public float range = 15f;
    
    [Header("Use bullets (default)")]
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use laser")] 
    public bool useLaser = false;
    public LineRenderer lineRenderer;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0, 0.5f);
    }

    private void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }
            }
            
            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    private void Laser()
    {
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
        }
        
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }

    private void LockOnTarget()
    {
        var dir = target.position - transform.position;
        var lookRotation = Quaternion.LookRotation(dir);
        // var rotation = lookRotation.eulerAngles;
        var rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void Shoot()
    {
        Debug.Log("Pew!");
        var bulletGameObject = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        var bullet = bulletGameObject.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        var shortestDistance = range;
        GameObject nearestEnemy = null;
        
        foreach (var enemy in enemies)
        {
            var distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
