using UnityEngine;
using UnityEngine.UI;

public class HotbarScript : MonoBehaviour
{
    public Image itemIcon;

    public void SetItem(Item item)
    {
        if (item == null)
        {
            itemIcon.enabled = false;
            return;
        }

        itemIcon.enabled = true;
        itemIcon.sprite = item.icon;
    }
}
