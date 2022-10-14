using TMPro;
using UnityEngine;

public class BusinessItemView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private TextMeshProUGUI _income;

    public void Initialize(BusinessItemModel model)
    {
        _name.text = model.Name;
        _level.text = model.LevelModel.Level.ToString();
        _income.text = model.Income.ToString();
    }
}