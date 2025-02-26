using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
namespace Core.Units {
    public abstract class UnitFactory : MonoBehaviour
    {

        public virtual Unit Create(Owner owner)
        {
            var unit = FactoryInstantiate(GetConfig().Prefab);
            unit.Initialize(GetConfig(), owner);
            return unit;
        }

        protected virtual Unit FactoryInstantiate(Unit prefab)
        {
            var instance = Instantiate(prefab, transform.position, Quaternion.identity);
            return instance;
        }

        protected abstract UnitConfig GetConfig();

    }
}
