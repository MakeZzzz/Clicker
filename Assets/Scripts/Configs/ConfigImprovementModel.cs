using System;
using UnityEngine;

namespace Configs
{
    [Serializable]
    public class ConfigImprovementModel 
    {
        public bool IsPurchased => _isPurchased;
        public string Name => _name;
        public float Price => _price;
        public float BoostIncome => _boostIncome;

        [SerializeField] private bool _isPurchased;
        [SerializeField] private string _name;
        [SerializeField] private float _price;
        [SerializeField] private float _boostIncome;

    }
}
