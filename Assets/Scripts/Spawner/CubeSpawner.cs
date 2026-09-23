using System.Collections;
using UnityEngine;

public class CubeSpawner : Spawner<Cube>
{
    [SerializeField] private Despawner _despawner;
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private float _positionBoundary = 20.0f;

    private void Start()
    {
        StartCoroutine(Work());
    }

    private IEnumerator Work()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn(GetRandomPosition());
            yield return wait;
        }
    }

    protected override void OnSpawned(Cube cube)
    {
        cube.LifeEnded += OnCubeLifeEnded;
    }

    private void OnCubeLifeEnded(Cube cube)
    {
        cube.LifeEnded -= OnCubeLifeEnded;
        _despawner.Despawn(cube);
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-_positionBoundary, _positionBoundary);
        float z = Random.Range(-_positionBoundary, _positionBoundary);
        return new Vector3(x, transform.position.y, z);
    }
}