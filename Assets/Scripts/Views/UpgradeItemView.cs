using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItemView : MonoBehaviour
{
    [SerializeField] private UpgradeItem _upgradeItem;

    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _incomeIncrease;
    [SerializeField] private TextMeshProUGUI _price;

    [SerializeField] private Button _upgradeButton;

    private void Initialize(UpgradeItemModel model, Action buttonCallback)
    {
        _name.text = model.Name;
        _incomeIncrease.text = $"Доход: +{model.IncomeIncrease * Constants.PercentageMultiplier}%";
        _price.text = model.IsPurchased ? Constants.Purchased : $"Цена: {model.Price}{Constants.BalanceSign}";

        _upgradeButton.onClick.AddListener(() => buttonCallback?.Invoke());
    }

    private void OnEnable()
    {
        _upgradeItem.Initialized += Initialize;
        _upgradeItem.DataChanged += OnDataChanged;
    }

    private void OnDataChanged()
    {
        _price.text = Constants.Purchased;
    }

    private void OnDisable()
    {
        _upgradeItem.Initialized -= Initialize;
        _upgradeItem.DataChanged -= OnDataChanged;
    }
}