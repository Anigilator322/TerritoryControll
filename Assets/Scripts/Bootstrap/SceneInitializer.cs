using Assets.Scripts.Point.Spawn;
using Core.Points.Spawn;
using Core.Units;
using Core.Units.Spawn;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Bootstrap
{
    public class SceneInitializer : MonoBehaviour
    {
        [SerializeField]
        private PointSpawnConfig PointSpawnConfig;
        [SerializeField]
        private List<PointSpawnPosition> PointSpawnPositions; 
        public void Initialize()
        {
            PointSpawner factory; 
            foreach(var pointSpawnPosition in PointSpawnPositions)
            {
                switch(pointSpawnPosition.UnitType)
                {
                    case UnitType.Troop:
                        factory = new TroopPointSpawner(PointSpawnConfig);
                        factory.SpawnPoint(pointSpawnPosition.Owner,pointSpawnPosition.transform);
                        break;
                    case UnitType.Tank:
                        
                        break;
                    case UnitType.Helicopter:
                        
                        break;
                    default:
                        factory = new TroopPointSpawner(PointSpawnConfig);
                        factory.SpawnPoint(pointSpawnPosition.Owner, pointSpawnPosition.transform);
                        break;
                }
            }
            Debug.Log("Level Initialized");
        }
    }
}
