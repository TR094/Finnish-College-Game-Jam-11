using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public string itemName;
    public Sprite icon;
    public bool dissapearOnPickup = true;

    public void Interact()
    {
        PlayerInventory inventory = FindFirstObjectByType<PlayerInventory>();

        if (inventory == null)
            return;

        if (inventory.AddItem(this) && dissapearOnPickup == true)
        {
            gameObject.SetActive(false);
        }
    }
}
