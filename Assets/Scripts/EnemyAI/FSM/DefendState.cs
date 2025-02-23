using Core.EnemyAI;
using Core.Units;
using UnityEngine;

namespace Assets.Scripts.EnemyAI.FSM
{
    public class DefendState : AIState
    {
        public DefendState(AIAgent agent) : base(agent) { }

        public override void Enter()
        {
            Debug.Log("Вход в состояние: Defend");
            Core.Units.Point target = null;
            foreach (var point in _pointObjectPool.PointsByOwner[Owner.Enemy])
            {
                if (point.PointStatus.IsUnderAttack)
                {
                    target = point;
                    break;
                }
            }
            if (target == null)
                return;
            _pointObjectPool.GetPointWithMaxHealth(Core.Units.Owner.Enemy).GetComponent<PointAttack>().PerformAttack(target);
        }

        public override void Update()
        {
            // Если угроза отпала, можно вернуться в состояние ожидания.
            if (!_agent.IsOwnBasesUnderAttack())
            {
                _agent.TransitionTo(new IdleState(_agent));
                return;
            }

            // Дополнительная логика защиты может быть добавлена здесь.
        }

        public override void Exit()
        {
            Debug.Log("Выход из состояния: Defend");
        }

    }
}
