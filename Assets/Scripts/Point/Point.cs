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
        [SerializeField] private Owner _owner;
        [SerializeField] private PointView _view;
        [SerializeField] private PointHealth _PointHealth;
        [SerializeField] private PointConfig _config;
        public Owner Owner => _owner;
    
        public Action<Owner> _ownerChanged;

        
        public PointConfig GetConfig()
        {
            return _config;
        }
        private void Start()
        {

            _PointHealth.Died += ChangeOwner;
            _PointHealth.InitializeHealth(_config.Health);
            _owner = _config.Owner;
        }
        public void ChangeOwner(Owner owner)
        {
            _owner = owner;
            _ownerChanged?.Invoke(owner);
        }
    }
}
