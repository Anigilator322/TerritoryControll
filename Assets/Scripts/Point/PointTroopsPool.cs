using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units
{
    public class PointTroopsPool : MonoBehaviour
    {
        
        [SerializeField] private PointHealth _pointHealth;
        [SerializeField] private Point _point;
        [SerializedDictionary("Unit Type", "Amount")]
        [SerializeField] private SerializedDictionary<UnitType, int> TroopsPool;

        //private int _troopsCount;


        private void Start()
        {
            TroopsPool = new SerializedDictionary<UnitType, int>();
            _pointHealth.HealApplied += AddTroops;
            _pointHealth.DamageApplied += RemoveTroops;
        }

        public SerializedDictionary<UnitType, int> TakeUnits()
        {
            SerializedDictionary<UnitType, int> returnPool = new SerializedDictionary<UnitType, int>(TroopsPool);
            TroopsPool.Clear();
            return returnPool;
        }
        private void ModifyDictionary(UnitType type, int value)
        {
            if(TroopsPool.TryGetValue(type, out var val))
            {
                //TroopsPool.Add(type, TroopsPool[type] + value);
                TroopsPool[type] += value;
            }
            else
            {
                TroopsPool.Add(type, value);
            }
        }
        public void AddTroops(UnitType type, int count)
        {
            ModifyDictionary(type, count);
        }
        public void AddTroops(int count)
        {
            ModifyDictionary(_point.GetConfig().GenerateUnit, count);
        }

        public void RemoveTroops(UnitType type, int count)
        {
            ModifyDictionary(type, -count);
        }
        public void RemoveTroops(int count)
        {
            ModifyDictionary(_point.GetConfig().GenerateUnit, -count);
        }
    }
}
