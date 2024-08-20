using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units
{
    public class PointHealth : MonoBehaviour, IDamageable, IHealable
    {
        private int health;
        public Action<Owner> Died;
        public void ApplyDamage(int damage, Owner from)
        {
            if (damage < 0)
                return;
            health -= damage;
            if (health <= 0)
            {
                Died?.Invoke(from);
                health = 0;
            }
        }

        public void ApplyHeal(int heal, Owner from)
        {
            health += heal;
        }
    }
}
