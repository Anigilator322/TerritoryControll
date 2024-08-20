using Core.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Movement
{
    public class MoveToTarget : UnitMovement
    {
        [SerializeField] private Vector2 _target;
        [SerializeField] private UnitConfig _config;

        protected override void Move()
        {
            transform.position = Vector2.MoveTowards(transform.position, _target, _config.Speed * Time.deltaTime);
        }
        public void SetTarget(Transform target)
        {
            _target = target.position;
        }
        public void SetShiftTarget(Transform target, Transform origin)
        {
            _target = target.position + (transform.position - origin.position);
        }

        public override void AdditionalMove()
        {
        }
    }
}
