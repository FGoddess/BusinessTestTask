using UnityEngine;

public class BusinessInitializer : MonoBehaviour
{
    [SerializeField] private Config _config;
    [SerializeField] private BusinessItem _itemPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private Balance _balance;

    [SerializeField] private SavesManager _savesManager;

    private void OnEnable()
    {
        _savesManager.DataLoaded += Initialize;
    }

    private void Initialize()
    {
        foreach (var businessItemModel in _config.BusinessItemModel)
        {
            var item = Instantiate(_itemPrefab, _container);
            item.Initialize(businessItemModel, _balance, businessItemModel.IncomeDelay);
        }
    }

    private void OnDisable()
    {
        _savesManager.DataLoaded -= Initialize;
    }
}