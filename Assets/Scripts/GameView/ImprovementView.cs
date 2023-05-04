using Controllers;
using TMPro;
using UnityEngine;

namespace GameView
{
    public class ImprovementView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _improvementName;
        [SerializeField] private TextMeshProUGUI _price;
        [SerializeField] private TextMeshProUGUI _boost;

        public void View(string name, float price, float boost)
        {
            _improvementName.text = name;
            _price.text = "PRICE: " + price;
            _boost.text = "BOOST: " + boost * 100 + "%";
        }
    }
}