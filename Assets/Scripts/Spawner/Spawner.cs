using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : Component
{
    [SerializeField] private Pool<T> _pool;

    protected Pool<T> Pool => _pool;

    protected T Spawn(Vector3 position)
    {
        T item = _pool.Get();
        item.transform.position = position;
        OnSpawned(item);
        return item;
    }

    protected virtual void OnSpawned(T item) { }
}