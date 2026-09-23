using TMPro;
using UnityEngine;

public abstract class PoolStatsView<T> : MonoBehaviour where T : Component
{
    [SerializeField] private Spawner<T> _spawner;
    [SerializeField] private Pool<T> _pool;

    [SerializeField] protected string PoolName;
    [SerializeField] protected TMP_Text PoolNameText;
    [SerializeField] private TMP_Text _spawnedText;
    [SerializeField] private TMP_Text _createdText;
    [SerializeField] private TMP_Text _activeText;

    private void Awake()
    {
        PoolNameText.text = PoolName;
    }

    private void OnEnable()
    {
        _spawner.Changed += UpdateView;
        _pool.Changed += UpdateView;
        UpdateView();
    }

    private void OnDisable()
    {
        _spawner.Changed -= UpdateView;
        _pool.Changed -= UpdateView;
    }

    protected void UpdateView()
    {
        _spawnedText.text = $"Заспавнено: {_spawner.TotalSpawned}";
        _createdText.text = $"Создано: {_pool.TotalCreated}";
        _activeText.text = $"Активных: {_pool.ActiveCount}";
    }
}