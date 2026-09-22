using System.Collections;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private BombSpawner _bombSpawner;

    private float _minDelay = 2.0f;
    private float _maxDelay = 5.0f;

    public void OnSurfaceTouched(Cube cube)
    {
        cube.SurfaceTouched -= OnSurfaceTouched;
        StartCoroutine(ReturnAndSpawnBomb(cube));
    }

    private IEnumerator ReturnAndSpawnBomb(Cube cube)
    {
        yield return new WaitForSeconds(Random.Range(_minDelay, _maxDelay));

        Vector3 position = cube.transform.position;
        _cubePool.Return(cube);

        _bombSpawner.SpawnAt(position);
    }
}