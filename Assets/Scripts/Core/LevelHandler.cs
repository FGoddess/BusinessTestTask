using System;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    private LevelModel _levelModel;
    private Balance _balance;

    public event Action<LevelModel, Action> Initialized;
    public event Action<int, int> DataChanged;

    public void Initialize(LevelModel model, Balance balance)
    {
        _levelModel = model;
        _balance = balance;

        Initialized?.Invoke(model, ButtonAction);
    }

    private void ButtonAction()
    {
        if (_balance.Money < _levelModel.Price) return;

        _balance.ChangeMoneyAmount(-_levelModel.Price);
        _levelModel.Level++;
        _levelModel.Price = (_levelModel.Level + 1) * _levelModel.BasePrice;

        DataChanged?.Invoke(_levelModel.Price, _levelModel.Level);
    }
}