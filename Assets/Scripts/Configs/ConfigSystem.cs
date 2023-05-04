using Models;
using ScriptableObjects;
using UnityEngine;

namespace Configs
{
    public class ConfigSystem : MonoBehaviour
    {
        [SerializeField] private BusinessConfigCollection businessConfigCollection;

        private BusinessModel[] _businessModels;
        private ImprovementModel[] _improvementModels;

        public void CreateBusinessModels()
        {
            _businessModels = new BusinessModel[businessConfigCollection.ConfigBusinessModel.Length];

            for (var i = 0; i < businessConfigCollection.ConfigBusinessModel.Length; i++)
            {
                var business = businessConfigCollection.ConfigBusinessModel[i];
                var businessImproves = CreateBusinessImproveModels(i);

                _businessModels[i] = new BusinessModel(business.Name, business.IncomeDelay, business.Level,
                    business.Income, business.Income, business.Price, businessImproves);
            }
        }

        private ImprovementModel[] CreateBusinessImproveModels(int index)
        {
            var businessModel = businessConfigCollection.ConfigBusinessModel[index];
            var typesImprovement = businessModel.TypesImprovement;
            var businessImproves = new ImprovementModel[typesImprovement.Length];

            for (var j = 0; j < typesImprovement.Length; j++)
            {
                var typeImprovement = typesImprovement[j];
                var businessImprove = new ImprovementModel(typeImprovement.Name, typeImprovement.Price,
                    typeImprovement.BoostIncome, typeImprovement.IsPurchased);
                businessImproves[j] = businessImprove;
            }

            return businessImproves;
        }

        public BusinessModel[] GetBuisnessModels()
        {
            return _businessModels;
        }
    }
}