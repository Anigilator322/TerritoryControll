using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units
{
    public class TroopDamageable :  MonoBehaviour, IDamageable
    {
        [SerializeField] private UnitCollisionFight _unitCollisionFight;
        [SerializeField] private Unit _unit;

        public void ApplyDamage(int damage, Owner from)
        {
            if (from == _unit.Owner)
                return;
            _unitCollisionFight.DisposeUnit();
        }
    }
}
