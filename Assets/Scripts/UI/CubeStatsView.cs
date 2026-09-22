using UnityEngine;

public class CubeStatsView : PoolStatsView
{
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private CubePool _pool;

    protected override void Subscribe()
    {
        _spawner.Changed += UpdateView;
        _pool.Changed += UpdateView;
    }

    protected override void Unsubscribe()
    {
        _spawner.Changed -= UpdateView;
        _pool.Changed -= UpdateView;
    }

    protected override int GetTotalSpawned() => _spawner.TotalSpawned;
    protected override int GetTotalCreated() => _pool.TotalCreated;
    protected override int GetActiveCount() => _pool.ActiveCount;
}