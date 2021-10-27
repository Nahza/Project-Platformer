using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private Pool _projectilePool;
    [SerializeField] private float _shootCooldown;

    private float _lastShotTime;

    private void Awake()
    {
        _lastShotTime = Time.time - _shootCooldown;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (isCooldownFinished())
            {
                shoot();  
            }
        }
    }

    private void shoot()
    {
        Poolable bullet = _projectilePool.GetElement();
        bullet.gameObject.SetActive(true);
        bullet.transform.position = _bulletSpawnPoint.position;
        bullet.transform.rotation = transform.rotation;

        _lastShotTime = Time.time;
    }

    private bool isCooldownFinished()
    {
        if (Time.time >= _lastShotTime + _shootCooldown)
        {
            return true;
        }

        return false;
    }
}
