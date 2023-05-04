using System;
using Systems;
using TMPro;
using UnityEngine;

namespace GameView
{
    public class BalanceView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _totalBalance;
        public void View(float totalBalance)
        {
            var balance = Convert.ToInt32(totalBalance).ToString();
            _totalBalance.text = "Balance: " + balance + "$";
        }
    }
}