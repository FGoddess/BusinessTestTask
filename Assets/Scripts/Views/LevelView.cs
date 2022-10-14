using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelView : MonoBehaviour
{
    [SerializeField] private LevelHandler _levelHandler;

    [SerializeField] private Button _levelUpButton;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private TextMeshProUGUI _level;

    private void OnEnable()
    {
        _levelHandler.Initialized += Initialize;
        _levelHandler.DataChanged += OnDataChanged;
    }

    private void Initialize(LevelModel model, Action buttonCallback)
    {
        OnDataChanged(model.Price, model.Level);
        Debug.Log(model.Price);
        _levelUpButton.onClick.AddListener(() => buttonCallback?.Invoke());
    }

    private void OnDataChanged(int priceValue, int level)
    {
        _price.text = $"{priceValue}{Constants.BalanceSign}";
        _level.text = $"{level}";
    }

    private void OnDisable()
    {
        _levelHandler.Initialized -= Initialize;
        _levelHandler.DataChanged -= OnDataChanged;
    }

    private void OnDestroy()
    {
        _levelUpButton.onClick.RemoveAllListeners();
    }
}