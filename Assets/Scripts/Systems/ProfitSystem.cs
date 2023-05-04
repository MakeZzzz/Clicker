using System.Collections;
using System.Collections.Generic;
using Configs;
using Controllers;
using Events;
using JetBrains.Annotations;
using Models;
using SimpleEventBus.Disposables;
using Systems;
using UnityEngine;

public class ProfitSystem : MonoBehaviour
{
   [SerializeField] private BalanceSystem _balanceSystem;
    public void ChangeIncome(BusinessModel model, ConfigSystem configSystem,ImprovementController[] improvementControllers)
    {
        if (_balanceSystem.GetBalance() < model.CurrentLevelPrice) return;
        if (model.isLevelClick)
        {
            model.ChangeLEvel();
            model.ResetLevelClick();
        }
        
        var eventDataRequest = new GetDecreaseEvent(model.CurrentLevelPrice);
        EventStream.Game.Publish(eventDataRequest);
        
        ChangeCurrentIncome(model,configSystem,improvementControllers);
        var newLevelPrice = ConfigMath.GetNewLevelPrice(model.CurentLevel, model.BasicPrice);
        model.ChangeLevelPrice(newLevelPrice);
    }

    public void ChangeCurrentIncome(BusinessModel model, ConfigSystem configSystem,ImprovementController[] improvementControllers)
    {
        var newIncome = ConfigMath.RecalculationIncome(model.CurentLevel, model.BasicPrice,
            improvementControllers);
        model.ChangeProfit(newIncome);
    }
   
}
