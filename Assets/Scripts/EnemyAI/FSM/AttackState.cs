using Core.EnemyAI;
using UnityEngine;

namespace Assets.Scripts.EnemyAI.FSM
{
    public class AttackState : AIState
    {
        public AttackState(AIAgent agent) : base(agent) { }

        public override void Enter()
        {
            Debug.Log("Вход в состояние: Attack");
            // Здесь можно добавить инициализацию атаки, например, выбор цели и отправку юнитов.
        }

        public override void Update()
        {
            // Если атака завершена (успешно или неуспешно), возвращаемся в состояние ожидания.
            if (_agent.AttackCompleted())
            {
                _agent.TransitionTo(new IdleState(_agent));
                return;
            }

            // Если во время атаки своя база оказывается под угрозой, переключаемся на защиту.
            if (_agent.IsOwnBasesUnderAttack())
            {
                _agent.TransitionTo(new DefendState(_agent));
                return;
            }

            // Логика продолжения атаки (например, обновление позиции юнитов) может выполняться здесь.
        }

        public override void Exit()
        {
            Debug.Log("Выход из состояния: Attack");
        }


    }
}
