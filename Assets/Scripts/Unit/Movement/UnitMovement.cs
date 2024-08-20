using System;
using UnityEngine;
namespace Core.Movement
{
    public abstract class UnitMovement : MonoBehaviour
    {
        protected Action OnMoveEnded;
        private void Update()
        {
            Move();
        }
        protected abstract void Move();
        public abstract void AdditionalMove();
        protected virtual void EndMove()
        {
            OnMoveEnded?.Invoke();
        }
    }
}
