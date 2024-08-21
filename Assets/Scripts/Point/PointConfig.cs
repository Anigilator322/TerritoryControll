using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units
{
    [CreateAssetMenu(fileName = "PointConfig", menuName = "Units/PointConfig", order = 1)]
    public class PointConfig : ScriptableObject
    {
        [SerializeField] private int _health;
        [SerializeField] private Owner _owner;

        public int Health => _health;
        public Owner Owner => _owner;
    }
}
