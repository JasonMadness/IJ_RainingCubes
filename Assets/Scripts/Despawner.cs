using System.Collections;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    [SerializeField] private CubePool _cubePool;

    private float _minDelay = 2.0f;
    private float _maxDelay = 5.0f;

    public void OnSurfaceTouched(Cube cube)
    {
        StartCoroutine(ReturnToPoolAfterDelay(cube));
        cube.SurfaceTouched -= OnSurfaceTouched;
    }

    private IEnumerator ReturnToPoolAfterDelay(Cube cube)
    {
        float delay = Random.Range(_minDelay, _maxDelay);
        yield return new WaitForSeconds(delay);
        _cubePool.Return(cube);
    }
}
