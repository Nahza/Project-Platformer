using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollision2D : MonoBehaviour
{
    [SerializeField] private LayerMask _layersToIgnore;
    
    [SerializeField] private UnityEvent _onCollisionEnter;
    [SerializeField] private UnityEvent _onCollisionStay;
    [SerializeField] private UnityEvent _onCollisionExit;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!isLayerIgnored(other.gameObject.layer))
        {
            _onCollisionEnter?.Invoke();
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (!isLayerIgnored(other.gameObject.layer))
        {
            _onCollisionStay?.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (!isLayerIgnored(other.gameObject.layer))
        {
            _onCollisionExit?.Invoke();
        }
    }

    private bool isLayerIgnored(int layer)
    {
        if (_layersToIgnore == (_layersToIgnore | (1 << layer)))
        {
            return true;
        }

        return false;
    }
}
