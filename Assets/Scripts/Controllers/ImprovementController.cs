using System;
using GameView;
using JetBrains.Annotations;
using Models;
using Systems;
using UnityEngine;

namespace Controllers
{
    public class ImprovementController : MonoBehaviour
    {
        public ImprovementModel GetImprovementModel => _improvementModel;

        [SerializeField] private BusinessController _businessController;
        [SerializeField] private ImprovementView _improvementView;

        private ImprovementModel _improvementModel;
        private TotalBalanceController _totalBalanceController;


        public void Initialize(TotalBalanceController totalBalanceController)
        {
            _totalBalanceController = totalBalanceController;
        }

        public void Initialize(ImprovementModel improvementModel)
        {
            _improvementModel = improvementModel;
        }

        [UsedImplicitly]
        public void ChangeIncome()
        {
            if (_improvementModel.IsBought)
            {
                return;
            }

            if (_totalBalanceController.GetBalance() < _improvementModel.Price)
            {
                return;
            }

            _improvementModel.ChangeCondition();
            _businessController.ChangeCurrentIncome();
            
            var eventDataRequest = new GetDecreaseEvent(_improvementModel.Price);
            EventStream.Game.Publish(eventDataRequest);
        }

        private void Update()
        {
            _improvementView.View(_improvementModel.Name, _improvementModel.Price, _improvementModel.Boost);
        }
    }
}