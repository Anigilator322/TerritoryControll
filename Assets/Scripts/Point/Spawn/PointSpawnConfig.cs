using UnityEngine;

namespace Core.Units.Spawn
{
    [CreateAssetMenu(fileName = "PointSpawnConfig", menuName = "Units/PointSpawnConfig", order = 1)]
    public class PointSpawnConfig : ScriptableObject
    {
        public Point PointPrefab;
        public PointConfig TroopPoint;
        public PointConfig TankPoint;
        public PointConfig HeliPoint;
    }
}
