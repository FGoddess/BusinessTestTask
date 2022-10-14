using UnityEngine;

public class BusinessItem : MonoBehaviour
{
    [SerializeField] private BusinessItemView _businessItemView;

    [SerializeField] private LevelHandler _levelHandler;

    [SerializeField] private UpgradeItem _firstUpgradeItem;
    [SerializeField] private UpgradeItem _secondUpgradeItem;

    [SerializeField] private SliderController _sliderController;
    [SerializeField] private IncomeCalculator _incomeCalculator;

    private BusinessItemModel _businessItemModel;
    private LevelModel _levelItemModel;
    private UpgradeItemModel _upgradeItemModel;

    public void Initialize(BusinessItemModel businessItemModel, Balance balance, float incomeDelay)
    {
        ValidatePrice(businessItemModel.LevelModel);

        _businessItemModel = businessItemModel;
        _businessItemView.Initialize(_businessItemModel);

        _levelHandler.Initialize(_businessItemModel.LevelModel, balance);
        _firstUpgradeItem.Initialize(_businessItemModel.FirstUpgradeItem, balance);
        _secondUpgradeItem.Initialize(_businessItemModel.SecondUpgradeItem, balance);

        _sliderController.Initialize(incomeDelay, businessItemModel.SliderValue, SaveSliderValue);
        _incomeCalculator.Initialize(balance, _businessItemModel);
    }

    private void SaveSliderValue(float value)
    {
        _businessItemModel.SliderValue = value;
    }

    private void ValidatePrice(LevelModel levelModel)
    {
        if (levelModel.Price == 0)
        {
            levelModel.Price = levelModel.BasePrice;
        }
    }
}