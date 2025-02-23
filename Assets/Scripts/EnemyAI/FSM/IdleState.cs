using Core.EnemyAI;
using UnityEngine;

namespace Assets.Scripts.EnemyAI.FSM
{
    public class IdleState : AIState
    {
        public IdleState(AIAgent agent) : base(agent) { }

        private float _thinkingTime;
        private float _elapsedTime;
        private bool _isThinking;

        public override void Enter()
        {
            Debug.Log("Вход в состояние: Idle");
            _thinkingTime = 5.0f;
            _elapsedTime = 0.0f;
            _isThinking = true;
        }

        public override void Update()
        {
            //Simple delay in decision making
            if (_isThinking)
            {
                _elapsedTime += Time.deltaTime;
                if (_elapsedTime >= _thinkingTime)
                {
                    _isThinking = false;
                    _elapsedTime = 0.0f;
                }
                return;
            }

            if (_agent.IsValuableToAttack())
            {
                _agent.TransitionTo(new AttackState(_agent));
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
            Debug.Log("Выход из состояния: Idle");
        }
    }
}
