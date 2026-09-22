using System.Collections.Generic;
using UnityEngine;

public abstract class Pool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T _prefab;

    private Queue<T> _pool = new();

    public T Get()
    {
        if (_pool.Count == 0)
            Create();

        T item = _pool.Dequeue();
        item.gameObject.SetActive(true);
        return item;
    }

    public void Return(T item)
    {
        item.gameObject.SetActive(false);
        _pool.Enqueue(item);
    }

    private void Create()
    {
        T newItem = Instantiate(_prefab, transform);
        Return(newItem);
    }
}