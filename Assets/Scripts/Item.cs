using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IPointerClickHandler
{
    public string itemName;
    public int itemID;
    public Sprite itemImg;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
        {
            return;
        }

        Inventory inventory = FindFirstObjectByType<Inventory>();
        if (inventory != null)
        {
            inventory.AddObject(this);
        }
        else
        {
            Debug.LogWarning("Inventory instance not found in the scene.");
        }
    }
}