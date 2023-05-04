using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using SimpleEventBus.Disposables;
using UnityEngine;

public class BalanceSystem : MonoBehaviour
{
    private float _totalBalance;
    private CompositeDisposable _subscription;
    private void Start()
    {
        _subscription = new CompositeDisposable()
        {
            EventStream.Game.Subscribe<GetIncomeEvent>(IncreaseTotalBalance),
            EventStream.Game.Subscribe<GetDecreaseEvent>(DecreaseTotalBalance)
        };
        
    }

    public void Initialize(float newBalance)
    {
        _totalBalance = newBalance;
    }
    public void IncreaseTotalBalance(GetIncomeEvent data)
    {
        _totalBalance += data.Profit;
    }
    public void DecreaseTotalBalance(GetDecreaseEvent data)
    {
        _totalBalance -= data.Lesion;
    }
    public float GetBalance()
    {
        return _totalBalance;
    }
    private void OnDestroy()
    {
        _subscription?.Dispose();
    }
}
