using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Cube _prefab;

    private Queue<Cube> _pool = new();

    public Cube Get()
    {
        if (_pool.Count == 0)
            Create();

        Cube cube = _pool.Dequeue();
        cube.gameObject.SetActive(true);
        
        return cube;
    }

    public void Return(Cube cube)
    {
        cube.gameObject.SetActive(false);
        _pool.Enqueue(cube);
    }

    private void Create()
    {
        Cube newCube = Instantiate(_prefab, transform);
        Return(newCube);
    }
}