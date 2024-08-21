using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units {
    public class TroopCollisionFight :UnitCollisionFight
    {
        protected override void OnTargetCollision(Collision2D collision, IDamageable damageable)
        {
            if(collision.gameObject.TryGetComponent<Point>(out Point point))
            {
                DisposeUnit();
            }
        }
    }
}
