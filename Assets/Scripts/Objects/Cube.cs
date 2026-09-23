using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour, IExplodable
{
    [SerializeField] private float _minLifetime = 2.0f;
    [SerializeField] private float _maxLifetime = 5.0f;

    private Renderer _renderer;
    private Color _defaultColor;
    private bool _surfaceTouched;

    public event Action<Cube> LifeEnded;

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
        if (_surfaceTouched) 
            return;

        if (other.gameObject.TryGetComponent<Platform>(out _))
        {
            _surfaceTouched = true;
            _renderer.material.color = Random.ColorHSV();
            StartCoroutine(WaitAndDie());
        }
    }

    private IEnumerator WaitAndDie()
    {
        float delay = Random.Range(_minLifetime, _maxLifetime);
        yield return new WaitForSeconds(delay);
        LifeEnded?.Invoke(this);
    }
}