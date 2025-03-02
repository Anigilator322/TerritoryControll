using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
namespace Core.Units {
    public class UnitFactory : MonoBehaviour
    {

        public Unit Create(Owner owner, UnitConfig config)
        {
            var unit = FactoryInstantiate(config.Prefab);
            unit.Initialize(config, owner);
            return unit;
        }

        protected Unit FactoryInstantiate(Unit prefab)
        {
            var instance = Instantiate(prefab, transform.position, Quaternion.identity);
            return instance;
        }
    }
}
