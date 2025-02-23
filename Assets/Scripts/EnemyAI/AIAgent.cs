using Assets.Scripts.EnemyAI.FSM;
using UnityEngine;
namespace Core.EnemyAI
{
    public class AIAgent : MonoBehaviour
    {
        private AIState currentState;

        void Start()
        {
            currentState = new IdleState(this);
            currentState.Enter();
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
            return false; // Заглушка
        }

        public bool IsOwnBasesUnderAttack()
        {
            return false; // Заглушка
        }

        public bool AttackCompleted()
        {
            return false; // Заглушка
        }

    }
}
