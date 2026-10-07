using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public string itemName;
    public Sprite icon;

    public void Interact()
    {
        PlayerInventory inventory = FindFirstObjectByType<PlayerInventory>();

        if (inventory == null)
            return;

        if (inventory.AddItem(this))
        {
            gameObject.SetActive(false);
        }
    }
}
