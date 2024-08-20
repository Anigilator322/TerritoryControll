using UnityEngine;
using UnityEngine.EventSystems;

namespace Core
{
    public abstract class MouseSelection : MonoBehaviour, ISelectable, IPointerDownHandler,IPointerUpHandler
    {
        public bool Selected { get; set; }

        public void OnPointerDown(PointerEventData eventData)
        {
            Select();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnSelectionEnded();
        }

        public virtual void OnSelected()
        {
            Debug.Log("select ended");
        }

        public virtual void OnSelectionEnded()
        {
            Debug.Log("end of selection");
        }

        public virtual void Select()
        {
            Debug.Log("select");   
        }
        
    }
}