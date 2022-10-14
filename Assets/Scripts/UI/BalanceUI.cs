using TMPro;
using UnityEngine;

public class BalanceUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private Balance _balance;

    private void OnEnable()
    {
        _balance.MoneyChanged += OnBalanceChanged;
    }

    private void OnDisable()
    {
        _balance.MoneyChanged += OnBalanceChanged;
    }

    private void OnBalanceChanged(int value)
    {
        _textMeshProUGUI.text = $"{Constants.BalanceText} {value}{Constants.BalanceSign}";
    }
}