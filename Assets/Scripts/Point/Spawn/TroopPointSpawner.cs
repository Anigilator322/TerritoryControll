using Core.Points.Spawn;
using Core.Units;
using Core.Units.Spawn;
using UnityEngine;

namespace Assets.Scripts.Point.Spawn
{
    public class TroopPointSpawner : PointSpawner
    {
        public TroopPointSpawner(PointSpawnConfig pointSpawnConfig) : base(pointSpawnConfig)
        {
        }

        public override Core.Units.Point SpawnPoint(Owner owner, Transform transform)
        {
            var point = Instantiate(_spawnConfig.PointPrefab, transform.position, Quaternion.identity);
            point.Initialize(_spawnConfig.TroopPoint, owner);
            PointSpawned?.Invoke(point);
            return point;
        }
    }
}
