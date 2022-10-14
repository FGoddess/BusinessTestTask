using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private LevelHandler _levelHandler;

    private float _incomeDelay;
    private bool _isWorking;

    private Action<float> _saveSliderValue;
    public event Action IncomeGotten;

    private void OnEnable()
    {
        _levelHandler.DataChanged += OnDataChanged;
        _levelHandler.Initialized += OnInitialized;
    }

    public void Initialize(float incomeDelay, float startValue, Action<float> callback)
    {
        _incomeDelay = incomeDelay;
        _slider.value = startValue;

        _saveSliderValue = callback;
    }

    private void OnInitialized(LevelModel model, Action callback)
    {
        _isWorking = model.Level > 0;
    }

    private void OnDataChanged(int price, int level)
    {
        _isWorking = level > 0;
    }

    private void Update()
    {
        if (!_isWorking) return;

        _slider.value += Time.deltaTime / _incomeDelay * _slider.maxValue;

        if (_slider.value >= _slider.maxValue)
        {
            _slider.value = _slider.minValue;
            IncomeGotten?.Invoke();
        }
    }

    private void OnDisable()
    {
        _levelHandler.DataChanged -= OnDataChanged;
        _levelHandler.Initialized -= OnInitialized;

        _saveSliderValue?.Invoke(_slider.value);
    }
}