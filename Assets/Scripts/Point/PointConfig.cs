using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units
{
    [CreateAssetMenu(fileName = "PointConfig", menuName = "Units/PointConfig", order = 1)]
    public class PointConfig : ScriptableObject
    {
        public int Health;
        public UnitType GenerateUnit;
        public float GenerationDelay;
    }
}
