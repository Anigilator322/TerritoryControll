using Assets.Scripts.EnemyAI;
using Assets.Scripts.EnemyAI.FSM;
using Core.Enemy;
using Core.Units;
using UnityEngine;
namespace Core.EnemyAI
{
    public class AIAgent : MonoBehaviour
    {
        private AIState currentState;
        private PointObjectPool _pointObjectPool;
        void Start()
        {
            currentState = new IdleState(this);
            currentState.Enter();
            _pointObjectPool = PointObjectPool.Instance();
        }

        void Update()
        {
            currentState.Update();
        }

        public void TransitionTo(AIState newState)
        {
            currentState.Exit();
            currentState = newState;
            currentState.Enter();
        }

        public bool IsValuableToAttack()
        {
            var aiFindTarget = new AITargetSeeker();
            if (aiFindTarget.TryToFindTarget(out Units.Point target))
            {
                foreach(var point in _pointObjectPool.PointsByOwner[Owner.Enemy])
                {
                    if (point.PointHealth.Health > target.PointHealth.Health)
                    {
                        Debug.Log("Valuable target found");
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsOwnBasesUnderAttack()
        {
            foreach(var point in _pointObjectPool.PointsByOwner[Owner.Enemy])
            {
                if (point.PointStatus.IsUnderAttack)
                {
                    return true;
                }
            }
            return false;
        }

        public bool AttackCompleted()
        {
            return true;     // Заглушка
        }

    }
}
