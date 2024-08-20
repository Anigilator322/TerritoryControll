using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Movement;
using System.Net.NetworkInformation;
using Unity.VisualScripting;

namespace Core.Units
{
    public class PointTroopSpawner : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPoints;
        
        [SerializeField] private float _spawnDelay = 0;
        [SerializeField] private TroopFactory _troopFactory;
        [SerializeField] private Squad _squadPref;

        private List<Vector2> _spawnPositions;
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
        IEnumerator SpawnGroup(Dictionary<UnitType, int> unitGroup, Owner owner, Transform target)
        {
            //var squad = Instantiate(_squadPref,transform);//
            //_spawnPositions = new List<Vector2>();

            foreach (var squads in unitGroup)
            {
                for (int i = 0; i < squads.Value;)
                {
                    foreach(Transform origin in _spawnPoints)
                    {
                        if (i >= squads.Value)
                            break;
                        Unit unit = _troopFactory.Create(squads.Key, owner);
                        unit.transform.position = origin.position;
                        unit.GetComponent<MoveToTarget>().SetShiftTarget(target,transform);
                        //squad.AddUnit(unit);//
                        i++;
                    }
                    
                    yield return new WaitForSeconds(_spawnDelay);

                }
            }
            yield return null;
        }

    }
}
