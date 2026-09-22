using TMPro;
using UnityEngine;

public abstract class PoolStatsView : MonoBehaviour
{
    [SerializeField] protected string PoolName;
    [SerializeField] protected TMP_Text PoolNameText;
    [SerializeField] protected TMP_Text SpawnedText;
    [SerializeField] protected TMP_Text CreatedText;
    [SerializeField] protected TMP_Text ActiveText;

    private void OnEnable()
    {
        Subscribe();
        UpdateView();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    protected abstract void Subscribe();
    protected abstract void Unsubscribe();
    protected abstract int GetTotalSpawned();
    protected abstract int GetTotalCreated();
    protected abstract int GetActiveCount();

    protected void UpdateView()
    {
        SpawnedText.text = $"Заспавнено: {GetTotalSpawned()}";
        CreatedText.text = $"Создано: {GetTotalCreated()}";
        ActiveText.text = $"Активных: {GetActiveCount()}";
    }
}