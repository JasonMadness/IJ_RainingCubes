using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Bomb : MonoBehaviour, IExplodable
{
    [SerializeField] private float _minLifetime = 2.0f;
    [SerializeField] private float _maxLifetime = 5.0f;
    [SerializeField] private float _explosionRadius = 5.0f;
    [SerializeField] private float _explosionForce = 10.0f;

    private Renderer _renderer;
    private Rigidbody _rigidbody;
    private Color _baseColor;
    private Coroutine _fadeRoutine;

    public event Action<Bomb> LifeEnded;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
        _baseColor = _renderer.material.color;
    }

    private void OnEnable()
    {
        SetAlpha(_baseColor.a);
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _fadeRoutine = StartCoroutine(FadeAndExplode());
    }

    private void OnDisable()
    {
        if (_fadeRoutine != null)
        {
            StopCoroutine(_fadeRoutine);
            _fadeRoutine = null;
        }
    }

    private IEnumerator FadeAndExplode()
    {
        float lifetime = Random.Range(_minLifetime, _maxLifetime);
        float elapsed = 0f;
        float startAlpha = _baseColor.a;

        while (elapsed < lifetime)
        {
            elapsed += Time.deltaTime;
            SetAlpha(Mathf.Lerp(startAlpha, 0f, elapsed / lifetime));
            yield return null;
        }

        SetAlpha(0f);
        LifeEnded?.Invoke(this);
        Explosion.Apply(transform.position, _explosionRadius, _explosionForce);
    }

    private void SetAlpha(float alpha)
    {
        Color color = _baseColor;
        color.a = alpha;
        _renderer.material.color = color;
    }
}