using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Point.UnitsProductions
{
    public abstract class UnitProduction
    {
        protected bool _isSpawnAllowed;

        public IEnumerator GenerateUnitsEnum(float generationDelay)
        {
            while (_isSpawnAllowed)
            {
                yield return new WaitForSeconds(generationDelay);
                GenerateUnit();
            }
            yield return null;
        }

        public abstract void GenerateUnit();
    }
}
