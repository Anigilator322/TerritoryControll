using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units
{
    public class PointsUnitProduction : MonoBehaviour
    {
        [SerializeField] private Point _point;
        [SerializeField] private PointHealth _health;
        [SerializeField] private bool _isSpawnAllowed;
        //[SerializeField] private UnitType _generateUnit;

        private void SetSpawn(Owner owner)
        {
            if (owner == Owner.Neutral)
                _isSpawnAllowed = false;
            else
                _isSpawnAllowed = true;
            StartCoroutine(GenerateUnitsEnum());
        }
        private void Start()
        {
            _isSpawnAllowed = _point.GetConfig().IsGenerationAllowed;
            _point._ownerChanged += SetSpawn;
            StartCoroutine(GenerateUnitsEnum());
        }
        private void OnDestroy()
        {
            StopCoroutine(GenerateUnitsEnum());
        }
        private void GenerateUnit()
        {
            _health.ApplyHeal(1);
        }

        IEnumerator GenerateUnitsEnum()
        {
            while(_isSpawnAllowed)
            {
                yield return new WaitForSeconds(_point.GetConfig().GenerationDelay);
                GenerateUnit();
            }
            yield return null;
        }
        
    }
}
