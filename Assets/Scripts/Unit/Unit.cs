using UnityEngine;
namespace Core.Units
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] protected UnitConfig _config;
        [SerializeField] public Owner Owner;

        public virtual void Initialize(UnitConfig config, Owner owner)
        {
            _config = config;
            Owner = owner;
        }
        public virtual void Initialize(UnitConfig config)
        {
            _config = config;
        }
    }
}
