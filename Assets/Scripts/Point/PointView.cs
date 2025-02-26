using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace Core.Units
{
    [RequireComponent(typeof(Point))]
    public class PointView : MonoBehaviour
    {

        Point _point;
        PointConsts _pointConsts;
        private PointHealth _pointHealth;

        [SerializeField]
        private TextMeshPro _healthTextMeshPro;
        void Start()
        {
            _point = GetComponent<Point>();
            _pointConsts = PointConsts.instance;
            gameObject.GetComponent<SpriteRenderer>().color = _pointConsts.GetColor(_point.Owner);
            _point.OwnerChanged += ChangeColor;
            _point.PointHealth.HealthChanged += UpdateHealth;
            UpdateHealth(_point.PointHealth.Health);
        }

        void ChangeColor(Point point)
        {
            gameObject.GetComponent<SpriteRenderer>().color = _pointConsts.GetColor(point.Owner);
        }

        void UpdateHealth(int health)
        {
            if(_pointHealth == null)
                TryGetComponent<PointHealth>(out _pointHealth);
            _healthTextMeshPro.text = health.ToString();
        }

        void Update()
        {
            
        }
    }
}
