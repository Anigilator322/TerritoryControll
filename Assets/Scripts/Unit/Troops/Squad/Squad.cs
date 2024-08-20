using Core.Movement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Core.Units
{
    public class Squad : MonoBehaviour
    {
        [SerializeField] private List<Unit> _units;
        [SerializeField] private FormationBase _formation;

        private List<Vector2> _formationPoints;
        private void Update()
        {
            SetFormation();
        }
        public void AddUnit(Unit unit)
        {
            _units.Add(unit);
            //add onDie listener to remove died units
        }
        public void RemoveUnit(Unit unit)
        {
            _units.Remove(unit);
        }
        public void MoveToTarget()
        {
            foreach(var point in _formationPoints)
            {
                
            }
        }
        public void SetFormation()
        {
            _formationPoints = _formation.EvaluatePoints().ToList();

            for(int i = 0; i < _units.Count; i++)
            {
                _units[i].transform.position = Vector2.MoveTowards(_units[i].transform.position,
                    transform.position + (Vector3)_formationPoints[i], 1.0f * Time.deltaTime);
            }
        }
    }
}
