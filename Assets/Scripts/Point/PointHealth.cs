using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units
{
    public class PointHealth : MonoBehaviour, IDamageable, IHealable
    {
        private int _health;
        public Action<Owner> Died;
        [SerializeField] private Point _point;

        public void InitializeHealth(int health)
        {
            _health = health;
        }
        public void ApplyDamage(int damage, Owner from)
        {
            if (damage < 0)
                return;

            if(_point.Owner == from)
            {
                ApplyHeal(damage);
            }
            else
            {
                _health -= damage;
                if (_health <= 0)
                {
                    Died?.Invoke(from);
                    _health = 0;
                }
            }
        }

        public void ApplyHeal(int heal)
        {
            _health += heal;
        }
    }
}
