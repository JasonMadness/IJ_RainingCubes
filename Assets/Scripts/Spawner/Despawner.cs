using System;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    [SerializeField] private CubePool _cubePool;

    public event Action<Vector3> Despawned;

    public void Despawn(Cube cube)
    {
        Vector3 position = cube.transform.position;
        _cubePool.Release(cube);
        Despawned?.Invoke(position);
    }
}