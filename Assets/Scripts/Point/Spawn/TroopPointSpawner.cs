using Core.Points.Spawn;
using Core.Units;
using UnityEngine;

namespace Assets.Scripts.Point.Spawn
{
    public class TroopPointSpawner : PointSpawner
    {
        public TroopPointSpawner(Core.Units.Point prefab, PointConfig pointSpawnConfig) : base(prefab,pointSpawnConfig)
        {
        }

        public override Core.Units.Point SpawnPoint(Owner owner, Transform transform)
        {
            var point = Instantiate(_prefab, transform.position, Quaternion.identity);
            point.Initialize(_spawnConfig, owner);
            PointSpawned?.Invoke(point);
            return point;
        }
    }
}
