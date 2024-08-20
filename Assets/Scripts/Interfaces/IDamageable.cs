using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units
{
    public interface IDamageable
    {
        void ApplyDamage(int damage, Owner from);
    }
}
