using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

public static class ConfigMath
{
    public static int GetNewLevelPrice(float level, float basicPrice)
    {
        var newLevelPrice = (1 + level) * basicPrice;
        return (int)newLevelPrice;
    }

    public static int RecalculationIncome(float level, float basicIncome, ImprovementController[] improvements)
    {
        var firstImprovementBoost =
            improvements[0].GetImprovementModel.IsBought ? improvements[0].GetImprovementModel.Boost : 0;
        var secondImprovementBoost =
            improvements[1].GetImprovementModel.IsBought ? improvements[0].GetImprovementModel.Boost : 0;

        var newIncome = level * basicIncome * (1 + firstImprovementBoost + secondImprovementBoost);

        return (int)newIncome;
    }
}