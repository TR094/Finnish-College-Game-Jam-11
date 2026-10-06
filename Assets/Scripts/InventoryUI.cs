using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUI : MonoBehaviour, IPointerClickHandler
{
    Inventory inventory = Object.FindFirstObjectByType<Inventory>();

    public void OnPointerClick(PointerEventData eventData)
    {
        // Get the GameObject that received the pointer click and try to get an InventoryItem from it
        if (eventData.pointerPress != null)
        {
            var item = eventData.pointerPress.GetComponent<InventoryItem>();
            if (item != null)
            {
                inventory.AddObject(item);
            }
        }
    }
}
