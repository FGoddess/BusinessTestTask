using System;
using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField] private SavesManager _savesManager;
    [SerializeField] private Config _config;
    [SerializeField] private int _money;

    public int Money => _money;

    public event Action<int> MoneyChanged;

    private void OnEnable()
    {
        _savesManager.DataLoaded += OnDataLoaded;
    }

    private void OnDataLoaded()
    {
        _money = _config.Money;
        MoneyChanged?.Invoke(_money);
    }

    public void ChangeMoneyAmount(int value)
    {
        _money += value;
        _config.Money = _money;
        MoneyChanged?.Invoke(_money);
    }

    private void OnDisable()
    {
        _config.Money = _money;
        _savesManager.DataLoaded -= OnDataLoaded;
    }
}