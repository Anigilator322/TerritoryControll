using Core.Point;
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
        public Owner Owner => _owner;
    
        public Action _ownerChanged;

        

        private void Start()
        {

            _PointHealth.Died += ChangeOwner;
        }
        public void ChangeOwner(Owner owner)
        {
            _owner = owner;
            _ownerChanged?.Invoke();
        }
    }
}
