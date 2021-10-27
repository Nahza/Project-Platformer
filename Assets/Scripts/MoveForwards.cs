using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MoveForwards : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * _moveSpeed;
    }
}
