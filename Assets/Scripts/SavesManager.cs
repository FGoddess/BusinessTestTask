using System;
using System.Linq;
using UnityEngine;

public class SavesManager : MonoBehaviour
{
    [SerializeField] private Config _config;

    public event Action DataLoaded;

    private void Start()
    {
        _config.Money = PlayerPrefs.GetInt("Money");

        foreach (var businessItemModel in _config.BusinessItemModel)
        {
            businessItemModel.Income = PlayerPrefs.GetInt($"{nameof(businessItemModel)}{businessItemModel.Id}Income",
                businessItemModel.BaseIncome);
            businessItemModel.SliderValue =
                PlayerPrefs.GetFloat($"{nameof(businessItemModel)}{businessItemModel.Id}Slider");
            businessItemModel.LevelModel.Price = PlayerPrefs.GetInt(
                $"{nameof(businessItemModel)}{businessItemModel.Id}Price", businessItemModel.LevelModel.BasePrice);
            businessItemModel.LevelModel.Level =
                PlayerPrefs.GetInt($"{nameof(businessItemModel)}{businessItemModel.Id}Level");
            businessItemModel.FirstUpgradeItem.IsPurchased =
                PlayerPrefs.GetInt($"{nameof(businessItemModel)}{businessItemModel.Id}FirstUpgrade") > 0;
            businessItemModel.SecondUpgradeItem.IsPurchased =
                PlayerPrefs.GetInt($"{nameof(businessItemModel)}{businessItemModel.Id}SecondUpgrade") > 0;
        }

        var firstBusiness = _config.BusinessItemModel.FirstOrDefault(b => b.Id == 0);

        if (firstBusiness != null && firstBusiness.LevelModel.Level == 0)
        {
            firstBusiness.LevelModel.Level = 1;
        }

        DataLoaded?.Invoke();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (!pauseStatus) return;

        PlayerPrefs.SetInt("Money", _config.Money);

        foreach (var businessItemModel in _config.BusinessItemModel)
        {
            PlayerPrefs.SetInt($"{nameof(businessItemModel)}{businessItemModel.Id}Income", businessItemModel.Income);
            PlayerPrefs.SetFloat($"{nameof(businessItemModel)}{businessItemModel.Id}Slider",
                businessItemModel.SliderValue);
            PlayerPrefs.SetInt($"{nameof(businessItemModel)}{businessItemModel.Id}Price",
                businessItemModel.LevelModel.Price);
            PlayerPrefs.SetInt($"{nameof(businessItemModel)}{businessItemModel.Id}Level",
                businessItemModel.LevelModel.Level);

            PlayerPrefs.SetInt($"{nameof(businessItemModel)}{businessItemModel.Id}FirstUpgrade",
                businessItemModel.FirstUpgradeItem.IsPurchased ? 1 : 0);
            PlayerPrefs.SetInt($"{nameof(businessItemModel)}{businessItemModel.Id}SecondUpgrade",
                businessItemModel.SecondUpgradeItem.IsPurchased ? 1 : 0);
        }
    }
}