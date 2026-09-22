using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _revolvePoint;
    [SerializeField] private float _revolveSpeed = 20f;

    private void Update()
    {
        _camera.transform.RotateAround(_revolvePoint.position, Vector3.up, _revolveSpeed * Time.deltaTime);
    }
}
