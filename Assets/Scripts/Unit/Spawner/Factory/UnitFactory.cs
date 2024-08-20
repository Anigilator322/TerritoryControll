using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units {
    public abstract class UnitFactory : MonoBehaviour
    {
        protected virtual Unit FactoryInstantiate(Unit prefab)
        {
            var instance = Instantiate(prefab, transform.position,Quaternion.identity);
            return instance;
        }
        public Unit Create(UnitType type, Owner owner)
        {
            var config = GetConfig(type);
            Unit instance = FactoryInstantiate(config.Prefab);
            instance.Initialize(config, owner);
            return instance;
        }

        public abstract UnitConfig GetConfig(UnitType type);
    }
}
