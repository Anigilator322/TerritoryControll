using Core.EnemyAI;
using UnityEngine;

namespace Assets.Scripts.EnemyAI.FSM
{
    public class IdleState : AIState
    {
        public IdleState(AIAgent agent) : base(agent) { }

        public override void Enter()
        {
            Debug.Log("Вход в состояние: Idle");
        }

        public override void Update()
        {
            // Пример проверки: если обнаружена слабость в базе противника, переходим в режим атаки.
            if (_agent.IsValuableToAttack())
            {
                _agent.TransitionTo(new AttackState(_agent));
                return;
            }

            // Если своя база подвергается атаке, переходим в режим защиты.
            if (_agent.IsOwnBasesUnderAttack())
            {
                _agent.TransitionTo(new DefendState(_agent));
                return;
            }

            // Дополнительная логика ожидания/расчёта может быть добавлена здесь.
        }

        public override void Exit()
        {
            Debug.Log("Выход из состояния: Idle");
        }
    }
}
