using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units
{
    [CreateAssetMenu(fileName = "PointConfig", menuName = "Units/PointConfig", order = 1)]
    public class PointConfig : ScriptableObject
    {
        private int _health;
        private Owner _owner;
    }
}
