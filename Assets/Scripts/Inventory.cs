using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform itemsParent;
    [SerializeField] private Button itemButtonPrefab;
    [SerializeField] private Hand hand;
    [SerializeField] private Vector2 itemOffset = new Vector2(80f, 0f);

    private readonly List<InventoryItem> items = new List<InventoryItem>();

    public void AddObject(InventoryItem item)
    {
        if (item == null || items.Contains(item))
        {
            return;
        }

        items.Add(item);
        item.gameObject.SetActive(false);

        Button itemButton = Instantiate(itemButtonPrefab, itemsParent);
        itemButton.name = item.itemName + " Button";

        RectTransform buttonRect = itemButton.GetComponent<RectTransform>();
        if (buttonRect != null)
        {
            buttonRect.anchoredPosition += itemOffset * (items.Count - 1);
        }

        Image icon = itemButton.GetComponent<Image>();
        if (icon != null)
        {
            icon.sprite = item.itemImg;
        }

        itemButton.onClick.AddListener(() => SelectItem(item));
    }

    private void SelectItem(InventoryItem item)
    {
        if (hand != null)
        {
            hand.HoldItem(item.itemImg);
        }
    }
}
