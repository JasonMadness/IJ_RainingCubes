using UnityEngine;

public class BombStatsView : PoolStatsView
{
    [SerializeField] private BombSpawner _spawner;
    [SerializeField] private BombPool _pool;

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