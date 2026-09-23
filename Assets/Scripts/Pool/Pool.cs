using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T _prefab;

    private readonly Queue<T> _pool = new();

    public event Action Changed;

    public int TotalCreated { get; private set; }
    public int ActiveCount => TotalCreated - _pool.Count;

    public T Get()
    {
        if (_pool.Count == 0)
            Create();

        T item = _pool.Dequeue();
        item.gameObject.SetActive(true);
        Changed?.Invoke();
        return item;
    }

    public void Release(T item)
    {
        item.gameObject.SetActive(false);
        _pool.Enqueue(item);
        Changed?.Invoke();
    }

    private void Create()
    {
        T newItem = Instantiate(_prefab, transform);
        TotalCreated++;
        Release(newItem);
    }
}