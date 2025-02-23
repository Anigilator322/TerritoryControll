using Core.EnemyAI;
using Core.Units;
using UnityEngine;

namespace Assets.Scripts.EnemyAI.FSM
{
    public class AttackState : AIState
    {
        public AttackState(AIAgent agent) : base(agent) { }
        private Core.Units.Point _target;
        public override void Enter()
        {
            Debug.Log("Вход в состояние: Attack");
            var targetSeeker = new AITargetSeeker();
            if(!targetSeeker.TryToFindTarget(out _target))
            {
                _agent.TransitionTo(new IdleState(_agent));
                return;
            }
            var attacker = _pointObjectPool.GetPointWithMaxHealth(Core.Units.Owner.Enemy);
            if (attacker.TryGetComponent<PointAttack>(out var pointAttack))
            {
                pointAttack.PerformAttack(_target);
            }
        }

        public override void Update()
        {
            if (_agent.AttackCompleted())
            {
                _agent.TransitionTo(new IdleState(_agent));
                return;
            }

            if (_agent.IsOwnBasesUnderAttack())
            {
                _agent.TransitionTo(new DefendState(_agent));
                return;
            }

        }

        public override void Exit()
        {
            Debug.Log("Выход из состояния: Attack");
        }


    }
}
