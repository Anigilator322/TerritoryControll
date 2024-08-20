using Core.Units;
using UnityEngine;

namespace Core
{
    public abstract class GameObjectFactory<T> : MonoBehaviour
    {
        [SerializeField] protected Transform _origin;
        protected T FactoryInstantiate(T prefab)
        {
            Debug.Log("Instant");
            GameObject instance = Instantiate(prefab as GameObject);
            T returnInstance = instance.GetComponent<T>();
            return returnInstance;
        }
    }
}
