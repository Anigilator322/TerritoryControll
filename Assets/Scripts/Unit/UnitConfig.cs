using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units
{
    public enum UnitType
    {
        Troop,
        Tank,
        Helicopter
    }
    [CreateAssetMenu(fileName = "UnitConfig", menuName = "Units/UnitConfig", order = 1)]
    public class UnitConfig: ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private UnitType _type;
        [Header("Characteristics")]
        [SerializeField] private int _health;
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        [Header("Components")]
        [SerializeField] private Unit _prefab;

        public Unit Prefab => _prefab;
        public UnitType Type => _type;
        public int Health => _health;
        public float Speed => _speed;
        public string Name => _name;
        public int Damage => _damage;
    }
}
