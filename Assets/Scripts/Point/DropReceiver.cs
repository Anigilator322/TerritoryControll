using UnityEngine;
using UnityEngine.EventSystems;
namespace Core.Units
{
    public class DropReceiver : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            if(eventData.pointerDrag != null)
            {
                Debug.Log("dropped");
                Point pointFrom = eventData.pointerDrag.gameObject.GetComponent<Point>();
            }
        }
    }
}