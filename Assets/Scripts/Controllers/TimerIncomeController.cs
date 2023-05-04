using System;
using Events;
using Models;
using Systems;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

namespace GameView
{
    public class TimerIncomeController : MonoBehaviour
    {
        [SerializeField] private DelayIncomeView _delayIncomeView;

        private BusinessModel _model;
        private float _timer;

        public void Initialize(BusinessModel model)
        {
            _model = model;
        }

        private void Update()
        {
            _delayIncomeView.UpdateSlider(_model, _model.DelayIncome);
        }
    }
}