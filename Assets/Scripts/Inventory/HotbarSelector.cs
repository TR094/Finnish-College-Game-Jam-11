using UnityEngine;
using UnityEngine.UI;

public class HotbarSelector : MonoBehaviour
{
    public PlayerInventory inventory;
    public HotbarScript[] slots;

    public Color normalColor = Color.white;
    public Color selectedColor = Color.yellow;

    private int selectedSlot = 0;

    public string itemEquipped;

    private void Start()
    {
        SelectSlot(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SelectSlot(0);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            SelectSlot(1);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            SelectSlot(2);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            SelectSlot(3);

        if (Input.GetKeyDown(KeyCode.Alpha5))
            SelectSlot(4);

        if (Input.GetKeyDown(KeyCode.Alpha6))
            SelectSlot(5);
    }

    private void SelectSlot(int index)
    {
        if (index < 0 || index >= inventory.items.Length)
            return;

        selectedSlot = index;

        for (int i = 0; i < slots.Length; i++)
        {
            Image background = slots[i].GetComponent<Image>();

            if (background != null)
            {
                background.color =
                    i == selectedSlot
                    ? selectedColor
                    : normalColor;
            }
        }
        EquipSelectedItem();
    }

    public void EquipSelectedItem()
    {
        Item item = inventory.items[selectedSlot];
        if (item == null)
        {
            Debug.Log("Nothing equipped.");
            return;
        }
        itemEquipped = item.itemName;
        Debug.Log("Equipped: " + item.itemName);
    }

}
