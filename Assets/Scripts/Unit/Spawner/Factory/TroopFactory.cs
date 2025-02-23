using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units
{
    public class TroopFactory : UnitFactory
    {
        [Header("Troop Configs")]
        [SerializeField] private UnitConfig _soldier;
        [SerializeField] private UnitConfig _tank;
        [SerializeField] private UnitConfig _helicopter;
        public override UnitConfig GetConfig(UnitType type)
        {
            switch(type)
            {
                case UnitType.Tank: 
                    return _tank;
                case UnitType.Troop: 
                    return _soldier;
                case UnitType.Helicopter:
                    return _helicopter;
                    default:
                    return _soldier;
            }
        }
    }
}
