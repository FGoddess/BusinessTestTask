using TMPro;
using UnityEngine;

public class IncomeCalculator : MonoBehaviour
{
    [SerializeField] private LevelHandler _levelHandler;
    [SerializeField] private UpgradeItem _firstUpgradeItem;
    [SerializeField] private UpgradeItem _secondUpgradeItem;

    [SerializeField] private SliderController _sliderController;
    [SerializeField] private TextMeshProUGUI _incomeText;

    private BusinessItemModel _businessItemModel;
    private Balance _balance;

    public void Initialize(Balance balance, BusinessItemModel businessItemModel)
    {
        _balance = balance;
        _businessItemModel = businessItemModel;
    }

    private void OnEnable()
    {
        _sliderController.IncomeGotten += OnIncomeGotten;
        _levelHandler.DataChanged += OnLevelHandlerDataChanged;
        _firstUpgradeItem.DataChanged += OnUpgradeItemDataChanged;
        _secondUpgradeItem.DataChanged += OnUpgradeItemDataChanged;
    }

    private void OnLevelHandlerDataChanged(int arg1, int arg2)
    {
        OnDataChanged();
    }

    private void OnUpgradeItemDataChanged()
    {
        OnDataChanged();
    }

    private void OnDataChanged()
    {
        var firstUpgradeItem = _businessItemModel.FirstUpgradeItem;
        var secondUpgradeItem = _businessItemModel.SecondUpgradeItem;

        var firstMultiplier = GetMultiplier(firstUpgradeItem.IsPurchased, firstUpgradeItem.IncomeIncrease);
        var secondMultiplier = GetMultiplier(secondUpgradeItem.IsPurchased, secondUpgradeItem.IncomeIncrease);

        var value = CalculateIncome(_businessItemModel.LevelModel.Level, _businessItemModel.BaseIncome, firstMultiplier,
            secondMultiplier);
        _incomeText.text = value.ToString();
        _businessItemModel.Income = value;
    }

    private void OnIncomeGotten()
    {
        _balance.ChangeMoneyAmount(_businessItemModel.Income);
    }

    private float GetMultiplier(bool isPurchased, float incomeIncrease)
    {
        return isPurchased ? incomeIncrease : 0f;
    }

    private int CalculateIncome(int level, int baseIncome, float firstMultiplier, float secondMultiplier)
    {
        return (int)(level * baseIncome * (1 + firstMultiplier + secondMultiplier));
    }

    private void OnDisable()
    {
        _sliderController.IncomeGotten -= OnIncomeGotten;
    }
}