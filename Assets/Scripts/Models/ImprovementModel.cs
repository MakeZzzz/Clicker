using System;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class ImprovementModel
    {
        public bool IsBought { get; private set; }
        public string Name { get; private set; }
        public float Price { get; private set; }
        public float Boost { get; private set; }

        public void ChangeCondition()
        {
            IsBought = true;
        }

        public ImprovementModel(string name, float price, float boost, bool isPurchased)
        {
            Name = name;
            Price = price;
            Boost = boost;
            IsBought = isPurchased;
        }
    }
}