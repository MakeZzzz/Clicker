using Controllers;
using TMPro;
using UnityEngine;

namespace GameView
{
    public class BusinessView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _businessName;
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private TextMeshProUGUI _income;
        [SerializeField] private TextMeshProUGUI _levelUpPrice;

        public void View(string name, float level, float income, float levelPrice)
        {
            _businessName.text = name;
            _level.text = "LVL " + level;
            _income.text = "INCOME: " + income;
            _levelUpPrice.text = levelPrice + "$";
        }
    }
}