using System;
using Events;
using GameView;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace Systems
{
    public class TotalBalanceController : MonoBehaviour
    {
        [SerializeField] private BalanceView _balanceView;
        [SerializeField] private ProfitSystem _profitSystem;
        [SerializeField] private BalanceSystem _balanceSystem;
        
        private CompositeDisposable _subscription;
        
        private void Start()
        {
            var eventDataRequest = new GetProfitEvent(this, _profitSystem);
            EventStream.Game.Publish(eventDataRequest);
        }
        
        private void OnDestroy()
        {
            _subscription?.Dispose();
        }

        public float GetBalance()
        {
            return _balanceSystem.GetBalance();
        }

        private void Update()
        {
            _balanceView.View(_balanceSystem.GetBalance());
        }
    }
}