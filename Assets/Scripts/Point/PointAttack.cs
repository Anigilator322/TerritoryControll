using Core.Movement;
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
            if (_point == target)
                return;
            _troopSpawner.AddGroupToSpawn(_troopPool.TakeUnits(), _point.Owner, target.transform);
            
        }
    }
}
