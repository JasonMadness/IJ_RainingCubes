using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Despawner : MonoBehaviour
{
    [SerializeField] private CubePool _cubePool;

    private float _minDelay = 2.0f;
    private float _maxDelay = 5.0f;

    public event Action<Vector3> CubeDespawned;

    public void OnSurfaceTouched(Cube cube)
    {
        cube.SurfaceTouched -= OnSurfaceTouched;
        StartCoroutine(ReleaseAfterDelay(cube));
    }

    private IEnumerator ReleaseAfterDelay(Cube cube)
    {
        float delay = Random.Range(_minDelay, _maxDelay);
        yield return new WaitForSeconds(delay);

        Vector3 position = cube.transform.position;
        _cubePool.Release(cube);
        CubeDespawned?.Invoke(position);
    }
}