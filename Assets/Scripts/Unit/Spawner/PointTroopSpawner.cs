using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Movement;
using System;
using System.Runtime.CompilerServices;

namespace Core.Units
{
    public class PointTroopSpawner : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private float _spawnDelay = 0;
        private UnitFactory _unitFactory;

        public Action<int> TroopSpawned;

        private Point _producingPoint;
        private void Start()
        {
            _producingPoint = GetComponent<Point>();
            gameObject.AddComponent(typeof(UnitFactory));
            _unitFactory = GetComponent<UnitFactory>();
        }

        public void AddGroupToSpawn(Dictionary<UnitType,int> unitGroup, Owner owner, Transform target)
        {
            StartCoroutine(SpawnGroup(unitGroup,owner,target));
        }

        private void RotatePointToTarget(Transform target)
        {
            Vector3 from = transform.up;
            Vector3 to = target.position - transform.position;

            float angle = Vector3.SignedAngle(from, to, transform.forward);
            transform.Rotate(0.0f, 0.0f, angle);
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        IEnumerator SpawnGroup(Dictionary<UnitType, int> unitGroup, Owner owner, Transform target)
        {
            RotatePointToTarget(target);
            foreach (var squads in unitGroup)
            {
                for (int i = 0; i < squads.Value;)
                {
                    foreach(Transform origin in _spawnPoints)
                    {
                        if (i >= squads.Value)
                            break;
                        Unit unit = _unitFactory.Create(owner, _producingPoint.GetConfig().GeneratingUnitConfig);
                        unit.transform.position = origin.position;
                        unit.GetComponent<MoveToTarget>().SetShiftTarget(target,transform);
                        unit.GetComponent<UnitCollisionFight>().Origin = gameObject.GetComponent<Point>();
           
                        i++;

                        TroopSpawned?.Invoke(1);
                    }
                    
                    yield return new WaitForSeconds(_spawnDelay);

                }
            }
            yield return null;
        }

    }
}
