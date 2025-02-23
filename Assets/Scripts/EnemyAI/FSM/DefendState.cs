using Core.EnemyAI;
using UnityEngine;

namespace Assets.Scripts.EnemyAI.FSM
{
    public class DefendState : AIState
    {
        public DefendState(AIAgent agent) : base(agent) { }

        public override void Enter()
        {
            Debug.Log("Вход в состояние: Defend");
            // Инициализация защиты: перераспределение юнитов для защиты базы.
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
