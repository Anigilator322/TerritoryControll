using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units
{
    public class SoldierFactory : UnitFactory
    {
        protected override UnitConfig GetConfig() 
        {
            var config = Resources.Load<UnitConfig>("Configs/Unit/Soldier");

            if (config == null)
            {
                Debug.LogError("Ќе удалось загрузить ScriptableObject!");
                return null;
            }
            else
            {
                Debug.Log("ScriptableObject успешно загружен!");
                return config;
            }
        }
    }
}
