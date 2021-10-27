using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Poolable : MonoBehaviour
{
    private Pool _returnPool;

    /// <summary>
    /// Sets the return pool of the object
    /// </summary>
    /// <param name="pool">The return pool</param>
    public void SetReturnPool(Pool pool)
    {
        _returnPool = pool;
    }

    /// <summary>
    /// Returns the object to its retrun pool
    /// </summary>
    public void ReturnToPool()
    {
        if (_returnPool != null)
        {
            _returnPool.AddToPool(this);
        }
    }
}
