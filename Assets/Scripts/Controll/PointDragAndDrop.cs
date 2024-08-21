using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Units
{
    public class PointDragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        public Action<Point> OnDrop;
        public Action<Point> OnDrag;
        //[SerializeField] Point _point;
        private Point selectedPoint;
        void IDragHandler.OnDrag(PointerEventData eventData)
        {
           
        }
        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            if (eventData.pointerEnter == null)
                return;
            if (eventData.pointerEnter.gameObject.TryGetComponent<Point>(out Point selected))
            {
                if (selected.Owner == Owner.Player)
                {
                    selectedPoint = selected;
                    OnDrag?.Invoke(selected);
                }
                else
                    selectedPoint = null;
            }
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            if (selectedPoint == null)
                return;
            Point target;
            if (eventData.pointerEnter == null)
                return;
            eventData.pointerEnter.gameObject.TryGetComponent(out target);
            if (target != null)
            {
                Debug.Log("perform attack");
                //selectedPoint.GetComponent<PointAttack>().PerformAttack(target);
                OnDrop?.Invoke(target);
            }
        }

    }
}
