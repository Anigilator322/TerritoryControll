using Core.Enemy;
using Core.Units;
using Core.Units.Spawn;
using System;
using UnityEngine;

namespace Core.Points.Spawn
{
    public abstract class PointSpawner : MonoBehaviour
    {
        protected PointSpawnConfig _spawnConfig;
        public Action<Point> PointSpawned;

        public PointSpawner(PointSpawnConfig pointSpawnConfig)
        {
            _spawnConfig = pointSpawnConfig;
            PointObjectPool.Instance.Subscribe(this);
        }

        public abstract Point SpawnPoint(Owner owner, Transform transform);
    }
}