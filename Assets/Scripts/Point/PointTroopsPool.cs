using AYellowpaper.SerializedCollections;
using Core.Units;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Point
{
    public class PointTroopsPool : MonoBehaviour
    {
        [SerializedDictionary("Unit Type", "Amount")]
        public SerializedDictionary<UnitType, int> TroopsPool;
        public void AddTroops(UnitType type, int count)
        {
            TroopsPool.Add(type, TroopsPool[type] + count);
        }
        public void RemoveTroops(UnitType type, int count)
        {
            if(TroopsPool[type] - count >= 0)
            {
                TroopsPool.Add(type, TroopsPool[type] - count);
            }
            else
            {
                Debug.LogWarning("Troops in point <= 0");
            }
        }
    }
}
