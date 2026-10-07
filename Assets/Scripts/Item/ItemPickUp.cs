using UnityEngine;

public class ItemClickPickup : MonoBehaviour
{
    private void OnMouseDown()
    {
        PlayerInventory inventory = FindFirstObjectByType<PlayerInventory>();

        if (inventory == null)
            return;

        Item item = GetComponent<Item>();

        if (item == null)
            return;

        if (inventory.AddItem(item))
        {
            Destroy(gameObject);
        }
    }
}


