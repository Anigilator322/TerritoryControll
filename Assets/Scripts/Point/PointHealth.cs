using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units
{
    public class PointHealth : MonoBehaviour, IDamageable, IHealable
    {
        [SerializeField] private int _health;
        public Action<Owner> Died;
        [SerializeField] private Point _point;

        public Action<int> DamageApplied;
        public Action<int> HealApplied;
        public Action<int> HealthChanged;

        public int Health => _health;

        [SerializeField] private PointTroopSpawner _troopSpawner;

        public void InitializeHealth(int health)
        {
            _health = health;
        }

        private void Start()
        {
            _troopSpawner.TroopSpawned -= ReduceHealth;
            _troopSpawner.TroopSpawned += ReduceHealth;
        }

        public void ApplyDamage(int damage, Owner from)
        {
            if (damage < 0)
                return;
            Debug.Log("Apply damage");
            if(_point.Owner == from)
            {
                ApplyHeal(damage);
            }
            else
            {
                _health -= damage;
                OnDamageApplied(damage);
                if (_health <= 0)
                {
                    Died?.Invoke(from);
                    _health = 0;
                }
            }
        }

        private void ReduceHealth(int count)
        {
            _health -= count;
        }

        public void ApplyHeal(int heal)
        {
            _health += heal;
            OnHealApplied(heal);
        }

        private void OnDamageApplied(int damage)
        {
            DamageApplied?.Invoke(damage);
            OnHealthChanged();
        }

        private void OnHealApplied(int heal)
        {
            HealApplied?.Invoke(heal);
            OnHealthChanged();
        }

        private void OnHealthChanged()
        {
            HealthChanged?.Invoke(_health);
        }
    }
}
