using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Units
{
    public class PointDragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        public Action<Point> OnDrop;
        public Action<Point> OnDrag;

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            OnDrag?.Invoke(eventData.pointerDrag.gameObject.GetComponent<Point>());
        }
        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {

        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            Point target;
            if (eventData.pointerEnter == null)
                return;
            eventData.pointerEnter.gameObject.TryGetComponent(out target);
            if(target != null)
                OnDrop?.Invoke(target);
        }

    }
}
