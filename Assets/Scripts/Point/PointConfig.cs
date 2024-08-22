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
        [SerializeField] private UnitType _generateUnit;
        [SerializeField] private float _generationDelay;
        [SerializeField] private bool _isGenerationAllowed = true;
        public UnitType generateUnit => _generateUnit;
        public int Health => _health;
        public Owner Owner => _owner;
        public float GenerationDelay => _generationDelay;
        public bool IsGenerationAllowed => _isGenerationAllowed;
    }
}
