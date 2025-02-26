using Core.Enemy;
using Core.Units;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Points.Spawn
{
    public abstract class PointSpawner : MonoBehaviour
    {
        protected PointConfig _spawnConfig;
        protected Point _prefab;
        public Action<Point> PointSpawned;

        protected PointSpawner(Point prefab,PointConfig pointSpawnConfig)
        {
            _spawnConfig = pointSpawnConfig;
            _prefab = prefab;
            PointObjectPool.Instance().Subscribe(this);
        }

        public abstract Point SpawnPoint(Owner owner, Transform transform);
    }
}