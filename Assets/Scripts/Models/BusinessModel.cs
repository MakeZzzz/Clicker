using System;

namespace Models
{
    [Serializable]
    public class BusinessModel
    {
        public string Name { get; set; }
        public float DelayIncome { get; set; }
        public float BasicPrice { get; set; }
        public float BaseIncome { get; set; }
        public float CurrentIncome { get; set; }
        public float CurentLevel { get; set; }
        public float CurrentLevelPrice { get; set; }

        public  ImprovementModel[] GetImprovemnts;

        public bool isLevelClick { get; private set; }


        public BusinessModel(string name, float incomeDelay, float currentLevel, float baseIncome, float currentIncome,
            float basicPrice, ImprovementModel[] improvementModels)
        {
            Name = name;
            DelayIncome = incomeDelay;
            CurentLevel = currentLevel;
            BaseIncome = baseIncome;
            CurrentIncome = currentIncome;
            BasicPrice = basicPrice;
            GetImprovemnts = improvementModels;
        }

        public void ClickLevel()
        {
            isLevelClick = true;
        }
        public void ResetLevelClick()
        {
            isLevelClick = false;
        }
        public void ChangeProfit(int newProfit)
        {
            CurrentIncome = newProfit;
        }

        public void ChangeLevelPrice(int newPrice)
        {
            CurrentLevelPrice = newPrice;
        }

        public void ChangeLEvel()
        {
            CurentLevel++;
        }
    }
}