using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    private Color _defaultColor;
    private bool _surfaceTouched;

    public event Action<Cube> SurfaceTouched;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _defaultColor = _renderer.material.color;
    }

    private void OnEnable()
    {
        _surfaceTouched = false;
        _renderer.material.color = _defaultColor;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_surfaceTouched == false)
        {
            SurfaceTouched?.Invoke(this);
            _renderer.material.color = Random.ColorHSV();
            _surfaceTouched = true;
        }
    }
}