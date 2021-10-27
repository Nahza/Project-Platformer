using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private GameObject _bulletPrefab;
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
        Instantiate(_bulletPrefab, _bulletSpawnPoint.position, transform.rotation);

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
