using System;
using UnityEngine;

[Serializable]
public class BusinessItemModel
{
    public int Id;
    public string Name;
    [HideInInspector] public int Income;
    public int BaseIncome;

    public float IncomeDelay;
    [HideInInspector] public float SliderValue;

    public LevelModel LevelModel;

    public UpgradeItemModel FirstUpgradeItem;
    public UpgradeItemModel SecondUpgradeItem;
}