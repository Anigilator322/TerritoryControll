using Core.Movement;
using Core.Point;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units
{
    public class PointAttack : MonoBehaviour
    {
        [SerializeField] private PointDragAndDrop _pointDragAndDrop;
        [SerializeField] private PointTroopSpawner _troopSpawner;
        [SerializeField] private PointTroopsPool _troopPool;
        [SerializeField] private Point _point;
        private void Start()
        {
            _pointDragAndDrop.OnDrop += PerformAttack;
        }
        public void PerformAttack(Point target)
        {
            _troopSpawner.AddGroupToSpawn(_troopPool.TroopsPool, _point.Owner, target.transform);
        }
    }
}
