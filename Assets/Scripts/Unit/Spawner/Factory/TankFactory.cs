using Core.Units;
using UnityEngine;
namespace Assets.Scripts.Unit.Spawner.Factory
{
    public class TankFactory : UnitFactory
    {
        protected override UnitConfig GetConfig()
        {
            var config = Resources.Load<UnitConfig>("Configs/Unit/Tank");
            return config ?? null;
        }
    }
}
