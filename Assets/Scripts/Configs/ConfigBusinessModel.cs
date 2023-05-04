using System;
using UnityEngine;

namespace Configs
{
    [Serializable]
    public class ConfigBusinessModel
    {
        public string Name => _name;
        public int Level => _level;
        public float Income => _income;
        public float IncomeDelay => _incomeDelay;
        public float Price => _price;

        public ConfigImprovementModel[] TypesImprovement => _typesImprovement;

        [SerializeField] private string _name;
        [SerializeField] private int _level;
        [SerializeField] private float _incomeDelay;
        [SerializeField] private float _price;
        [SerializeField] private float _income;

        [SerializeField] private ConfigImprovementModel[] _typesImprovement;


    }
}
