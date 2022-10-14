using System;
using UnityEngine;

public class UpgradeItem : MonoBehaviour
{
    private UpgradeItemModel _upgradeItemModel;
    private Balance _balance;

    public event Action<UpgradeItemModel, Action> Initialized;
    public event Action DataChanged;

    public void Initialize(UpgradeItemModel model, Balance balance)
    {
        _upgradeItemModel = model;
        _balance = balance;

        Initialized?.Invoke(_upgradeItemModel, ButtonAction);
    }

    private void ButtonAction()
    {
        if (_upgradeItemModel.IsPurchased || _upgradeItemModel.Price > _balance.Money) return;

        _balance.ChangeMoneyAmount(-_upgradeItemModel.Price);
        _upgradeItemModel.IsPurchased = true;

        DataChanged?.Invoke();
    }
}