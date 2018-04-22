using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Lobby
{
    public class DraggablePanel : MonoBehaviour, IDragHandler
    {
        public void OnDrag(PointerEventData eventData)
        {
            transform.Translate(eventData.delta);
        }
    }
}