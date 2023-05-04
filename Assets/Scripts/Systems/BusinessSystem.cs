using System.Collections.Generic;
using Configs;
using Controllers;
using Models;
using UnityEngine;

namespace Systems
{
    public class BusinessSystem : MonoBehaviour
    {
        [SerializeField] private BusinessController _businessPrefab;
        [SerializeField] private RectTransform _parent;
        [SerializeField] private ConfigSystem _configSystem;
    
        private readonly List<BusinessController> _controllers = new ();

        public void SpawnBusiness(BusinessModel[] businessModels)
        {
            foreach (var businessModel in businessModels)
            {
                var business = Instantiate(_businessPrefab, _parent);
                business.Initialize(businessModel, _configSystem);
                _controllers.Add(business);
            }
        }
        public void DeleteControllers()
        {
            foreach (var controller in _controllers)
            {
                Destroy(controller.gameObject);
            }
            _controllers.Clear();
        }
    
    }
}