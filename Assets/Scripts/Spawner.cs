using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Despawner _despawner;
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private float _positionBoundary = 20.0f;

    private void Create()
    {
        Cube cube = _cubePool.Get();
        cube.transform.position = GetRandomPosition();
        cube.SurfaceTouched += _despawner.OnSurfaceTouched;
    }
    
    private Vector3 GetRandomPosition()
    {
        float positionX = Random.Range(-_positionBoundary, _positionBoundary);
        float positionZ = Random.Range(-_positionBoundary, _positionBoundary);
        return new Vector3(positionX, transform.position.y, positionZ);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            Create();
    }
}
