using UnityEngine;

public class HotbarUIScript : MonoBehaviour
{
    public PlayerInventory inventory;
    public HotbarScript[] slots;

    private void Start()
    {
        UpdateHotbar();
    }

    public void UpdateHotbar()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetItem(inventory.items[i]);
        }
    }
}
