using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units
{
    [RequireComponent(typeof(Point))]
    public class PointView : MonoBehaviour
    {

        Point _point;
        PointConsts _pointConsts;
        void Start()
        {
            _point = GetComponent<Point>();
            _pointConsts = PointConsts.instance;
            gameObject.GetComponent<SpriteRenderer>().color = _pointConsts.GetColor(_point.Owner);
            _point.OwnerChanged += ChangeColor;
        }

        void ChangeColor(Point point)
        {
            gameObject.GetComponent<SpriteRenderer>().color = _pointConsts.GetColor(point.Owner);
        }
        void Update()
        {
            
        }
    }
}
