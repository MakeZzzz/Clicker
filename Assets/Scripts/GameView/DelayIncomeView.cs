using System.Collections;
using System.Collections.Generic;
using Events;
using GameView;
using Models;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class DelayIncomeView : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private float _timer;
  
    
    public void UpdateSlider(BusinessModel model,float maxValue)
    {
        _slider.maxValue = maxValue;
        if (model.CurentLevel == 0)
        {
            return;
        }

        _timer += Time.deltaTime;
        _slider.value = _timer;
        if (_timer >= model.DelayIncome)
        {
            var eventDataRequest = new GetIncomeEvent(model.CurrentIncome);
            EventStream.Game.Publish(eventDataRequest);
            _timer = 0;
        }
    }
}
