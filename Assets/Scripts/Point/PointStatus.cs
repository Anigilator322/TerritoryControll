using Core.Units;
using UnityEngine;

namespace Assets.Scripts.Point
{
    public class PointStatus : MonoBehaviour
    {
        [SerializeField] private PointHealth _pointHealth;

        private void Start()
        {
            _pointHealth.DamageApplied += SetUnderAttack;
        }

        public bool IsUnderAttack { get; private set; }
        private float _timeOfAttack = 4f;
        private float _elapsedTime = 0f;

        public void SetUnderAttack(int dmg)
        {
            IsUnderAttack = true;
        }

        private void Update()
        {
            if (IsUnderAttack)
            {
                _elapsedTime += Time.deltaTime;
                if (_elapsedTime >= _timeOfAttack)
                {
                    IsUnderAttack = false;
                    _elapsedTime = 0f;
                }
            }
        }
    }
}
