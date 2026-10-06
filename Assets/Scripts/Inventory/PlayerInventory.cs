using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Item[] items = new Item[5];

    public HotbarUIScript hotbarUI;

    public bool AddItem(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;

                Debug.Log("Added " + item.itemName + " to inventory slot " + i);

                if (hotbarUI != null)
                {
                    hotbarUI.UpdateHotbar();
                }

                return true;
            }
        }

        Debug.Log("Inventory full!");
        return false;
    }

    public Item GetItem(int slot)
    {
        if (slot < 0 || slot >= items.Length)
            return null;

        return items[slot];
    }
}
