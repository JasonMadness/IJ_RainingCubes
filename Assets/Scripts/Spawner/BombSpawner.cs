using UnityEngine;

public class BombSpawner : Spawner<Bomb>
{
    [SerializeField] private Despawner _despawner;

    private void OnEnable()
    {
        _despawner.CubeDespawned += SpawnAt;
    }
    private void OnDisable()
    {
        _despawner.CubeDespawned -= SpawnAt;
    }

    private void SpawnAt(Vector3 position)
    {
        Bomb bomb = Spawn(position);
        bomb.LifeEnded += OnBombLifeEnded;
    }

    private void OnBombLifeEnded(Bomb bomb)
    {
        bomb.LifeEnded -= OnBombLifeEnded;
        Pool.Release(bomb);
    }
}