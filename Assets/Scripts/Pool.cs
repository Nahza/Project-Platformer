using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Pool : ScriptableObject
{
    [SerializeField] private Poolable _defaultObjectPrefab;

    private Queue<Poolable> _pool = new Queue<Poolable>();

    /// <summary>
    /// Gets an element from the pool or instantiates a new object
    /// </summary>
    /// <returns>An element from the pool, or a newly instantiated object</returns>
    public Poolable GetElement()
    {
        if (_pool.Count > 0)
        {
            return _pool.Dequeue();
        }

        Poolable obj = Instantiate(_defaultObjectPrefab);
        obj.SetReturnPool(this);

        return obj;
    }
    
    /// <summary>
    /// Adds an object to the pool
    /// </summary>
    /// <param name="obj">The object to add</param>
    public void AddToPool(Poolable obj)
    {
        _pool.Enqueue(obj);
    }
}
