using Core.Enemy;
using Core.EnemyAI;

namespace Assets.Scripts.EnemyAI.FSM
{
    public abstract class AIState
    {
        protected AIAgent _agent;
        protected PointObjectPool _pointObjectPool;

        public AIState(AIAgent agent)
        {
            _agent = agent;
            _pointObjectPool = PointObjectPool.Instance;
        }

        public abstract void Enter();

        public abstract void Update();

        public abstract void Exit();
    }
}
