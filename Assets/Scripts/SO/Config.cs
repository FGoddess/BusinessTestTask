using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Config", fileName = "Config", order = 0)]
public class Config : ScriptableObject
{
    public List<BusinessItemModel> BusinessItemModel;
    public int Money;
}