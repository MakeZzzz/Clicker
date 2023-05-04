using System;
using Configs;
using Events;
using GameView;
using JetBrains.Annotations;
using Models;
using SimpleEventBus.Disposables;
using Systems;
using UnityEngine;

namespace Controllers
{
    public class BusinessController : MonoBehaviour
    {
        public BusinessModel Model { get; private set; }

        [SerializeField] private TimerIncomeController timerIncomeController;
        [SerializeField] private ImprovementController[] _improvementControllers;
        [SerializeField] private BusinessView _businessView;

        private ConfigSystem _configSystem;
        private CompositeDisposable _subscription;
        private ProfitSystem _profitSystem;

        private void Awake()
        {
            _subscription = new CompositeDisposable()
            {
                EventStream.Game.Subscribe<GetProfitEvent>(GetProfit),
            };
        }

        private void Start()
        {
            timerIncomeController.Initialize(Model);
            OnStart();

            for (var i = 0; i < _improvementControllers.Length; i++)
            {
                _improvementControllers[i].Initialize(Model.GetImprovemnts[i]);
            }
        }

        [UsedImplicitly]
        private void GetProfit(GetProfitEvent profit)
        {
            _profitSystem = profit.GetProfit();
            foreach (var improvementController in _improvementControllers)
            {
                improvementController.Initialize(profit.GetBalance());
            }
        }

        private void OnStart()
        {
            var newLevelPrice = ConfigMath.GetNewLevelPrice(Model.CurentLevel, Model.BasicPrice);
            Model.ChangeLevelPrice(newLevelPrice);
        }

        public void Initialize(BusinessModel model, ConfigSystem configSystem)
        {
            Model = model;
            _configSystem = configSystem;
        }

        public void ClickLevel()
        {
            Model.ClickLevel();
        }

        [UsedImplicitly]
        public void ChangeIncome()
        {
            _profitSystem.ChangeIncome(Model, _configSystem, _improvementControllers);
        }

        public void ChangeCurrentIncome()
        {
            _profitSystem.ChangeCurrentIncome(Model, _configSystem, _improvementControllers);
        }

        private void OnDestroy()
        {
            _subscription?.Dispose();
        }

        private void Update()
        {
            _businessView.View(Model.Name, Model.CurentLevel, Model.CurrentIncome,
                Model.CurrentLevelPrice);
        }
    }
}