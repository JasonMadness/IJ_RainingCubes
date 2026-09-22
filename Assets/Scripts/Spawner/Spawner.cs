using System;
using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : Component
{
    [SerializeField] private Pool<T> _pool;

    protected Pool<T> Pool => _pool;

    public int TotalSpawned { get; private set; }

    public event Action Changed;

    protected T Spawn(Vector3 position)
    {
        T item = _pool.Get();
        item.transform.position = position;
        OnSpawned(item);

        TotalSpawned++;
        Changed?.Invoke();
        return item;
    }

    protected virtual void OnSpawned(T item) { }
}