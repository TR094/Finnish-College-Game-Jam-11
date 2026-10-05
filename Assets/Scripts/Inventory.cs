using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public string itemName;
    public int itemID;
    public InventoryItem(string name, int id)
    {
        itemName = name;
        itemID = id;
    }
}

public class Inventory : MonoBehaviour
{
    List<InventoryItem> inventory = new List<InventoryItem>();

    void Start()
    {
        Inventory inventory = new Inventory();
    }

    void Update()
    {

    }

    void AddObjectInventory(InventoryItem item)
    {
        inventory.Add(item);
    }
}
