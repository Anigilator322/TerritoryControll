using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units {
    public class TroopCollisionFight :UnitCollisionFight
    {
        protected override void OnTargetCollision(Collider2D collision, IDamageable damageable)
        {
            Debug.Log("Target Collision");
            if(collision.gameObject.TryGetComponent<Point>(out Point point))
            {
                DisposeUnit();
            }
        }
    }
}
