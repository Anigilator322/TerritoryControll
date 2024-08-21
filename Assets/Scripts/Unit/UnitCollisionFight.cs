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
        private bool _isUnitDisposed;
        [SerializeField] private UnitDisposeType _disposeType;
        [SerializeField] private Unit _unit;
        public Action OnUnitDisposed;
        [SerializeField] private Point _origin;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_isUnitDisposed)
                return;
            if (collision.gameObject == _origin.gameObject)
                return;
            if(collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.ApplyDamage(_unit.GetConfig().Damage, _unit.Owner);
                OnTargetCollision(collision, damageable);
            }
            if (_disposeType == UnitDisposeType.OnTargetCollisionEnter)
                DisposeUnit();

        }
        protected virtual void OnTargetCollision(Collision2D collision, IDamageable damageable)
        {

        }
        protected virtual void OnOtherCollisionEnter(Collision2D collision)
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
