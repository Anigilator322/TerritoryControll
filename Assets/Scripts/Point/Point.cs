using Assets.Scripts.Point;
using Core.Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units
{
    public enum Owner
    {
        Enemy,
        Player,
        Neutral
    }
    [RequireComponent(typeof(PointHealth))]
    public class Point : MonoBehaviour
    {
        [SerializeField] private PointView _view;
        [SerializeField] private PointHealth _pointHealth;
        private Owner _owner;
        private PointConfig _config;

        public Owner Owner => _owner;
        public PointHealth PointHealth => _pointHealth;

        public bool IsGenerationAllowed { get; private set; }

        public Action<Point> OwnerChanged;

        public PointStatus PointStatus;

        public void Initialize(PointConfig config, Owner owner)
        {
            PointObjectPool.Instance.Subscribe(this);
            ChangeOwner(owner);
            _config = config;
            _pointHealth.Died += ChangeOwner;
            _pointHealth.InitializeHealth(_config.Health);
        }

        public PointConfig GetConfig()
        {
            return _config;
        }

        public void ChangeOwner(Owner owner)
        {
            _owner = owner;
            IsGenerationAllowed = owner != Owner.Neutral;
            OwnerChanged?.Invoke(this);
        }
    }
}
