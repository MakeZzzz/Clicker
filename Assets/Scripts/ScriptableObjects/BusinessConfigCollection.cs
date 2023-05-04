using Configs;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "business", menuName = "Businesses")]
    public class BusinessConfigCollection : ScriptableObject
    {
        public ConfigBusinessModel[] ConfigBusinessModel => _configBusinessModels;
    
        [SerializeField] private ConfigBusinessModel[] _configBusinessModels;
    
    }
}

// Zona Кухни
//     name 
//    Item то что она производит кола   котлета 
//    
//     время приготовления
//     improvement[]
//    
//   public class ConfigKitchenZone
//   {
//
//       private string НазваниеНашейЗоны;
//       private ConfigImprovements[] ЗдесьМыХранимНужныеУлучшенияНашейЗоны; // например по автоматом с колой(сколько стоит новый автомат)
//       private ConfigItem[] ПродуктКоторыйМыПроизводим; 
//
//   }
//
// public class ConfigImprovements
// {
//     // здесь храним таблицу улучшений
// }
//
// public class ConfigItem
// {
//     // название нашего продукта
//     // время за сколько производим
//     //сумма вознаграждения , которую мы получим от клиента за этот продукт  
// }