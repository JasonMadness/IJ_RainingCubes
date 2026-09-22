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
        WaitForSeconds delay = new(_delay);

        while (enabled)
        {
            Spawn(GetRandomPosition());
            yield return delay;
        }
    }

    protected override void OnSpawned(Cube cube)
    {
        cube.SurfaceTouched += _despawner.OnSurfaceTouched;
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-_positionBoundary, _positionBoundary);
        float z = Random.Range(-_positionBoundary, _positionBoundary);
        return new Vector3(x, transform.position.y, z);
    }
}