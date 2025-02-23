using Core.Enemy;

namespace Assets.Scripts.EnemyAI
{
    public class AITargetSeeker
    {
        private PointObjectPool _pointObjectPool;
        public AITargetSeeker()
        {
            _pointObjectPool = PointObjectPool.Instance;
        }

        public bool TryToFindTarget(out Core.Units.Point target)
        {
            if (_pointObjectPool?.PointsByOwner[Core.Units.Owner.Neutral]?.Count > 0)
            {
                target = _pointObjectPool.PointsByOwner[Core.Units.Owner.Neutral][0];
                return true;
            }

            if(_pointObjectPool?.PointsByOwner[Core.Units.Owner.Player]?.Count > 0)
            {
                target = _pointObjectPool.GetPoinWithMinHealth(Core.Units.Owner.Player);
                return true;
            }

            target = null;
            return false;
        }
    }
}
