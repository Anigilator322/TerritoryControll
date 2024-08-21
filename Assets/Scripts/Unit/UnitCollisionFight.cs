using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units
{
    public enum UnitDisposeType
    {
        OnTargetCollisionEnter,
        Manual
    }
    public abstract class UnitCollisionFight : MonoBehaviour
    {
        private bool _isUnitDisposed = false;
        [SerializeField] private UnitDisposeType _disposeType;
        [SerializeField] private Unit _unit;
        public Action OnUnitDisposed;
        [HideInInspector] public Point Origin;
        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (_isUnitDisposed)
                return;
            
            if (collision.gameObject == Origin.gameObject)
                return;
            if(collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.ApplyDamage(_unit.GetConfig().Damage, _unit.Owner);
                OnTargetCollision(collision, damageable);
            }
            if (_disposeType == UnitDisposeType.OnTargetCollisionEnter)
                DisposeUnit();

        }
        protected virtual void OnTargetCollision(Collider2D collision, IDamageable damageable)
        {

        }
        protected virtual void OnOtherCollisionEnter(Collider2D collision)
        {

        }
        protected virtual void OnUnitDispose()
        {

        }
        public void DisposeUnit()
        {
            OnUnitDispose();
            _isUnitDisposed = true;
            Destroy(gameObject);
            OnUnitDisposed?.Invoke();

        }

    }
}
