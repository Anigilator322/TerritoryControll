using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units {
    public class PointDamageable : MonoBehaviour, IDamageable
    {
        [SerializeField] private PointHealth _pointHealth;
        public void ApplyDamage(int damage, Owner from)
        {
            _pointHealth.ApplyDamage(damage, from);
        }
    }
}
