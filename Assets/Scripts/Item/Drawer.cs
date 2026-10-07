using UnityEngine;
using UnityEngine.UI;

public class Drawer : MonoBehaviour, IInteractable
{
    public Sprite normalSprite;
    public Sprite openSprite;
    public GameObject objectInside;

    private bool isOpen = false;
    private bool itemTaken = false;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();

        // Item starts hidden while drawer is closed
        if (objectInside != null)
        {
            objectInside.SetActive(false);
        }

        image.sprite = normalSprite;
    }

    public void Interact()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            // Open drawer
            image.sprite = openSprite;

            // Show item if it hasn't been taken
            if (!itemTaken && objectInside != null)
            {
                objectInside.SetActive(true);
            }
        }
        else
        {
            // Close drawer
            image.sprite = normalSprite;

            // Hide item when drawer closes
            if (objectInside != null)
            {
                objectInside.SetActive(false);
            }
        }
    }

    public void ItemTaken()
    {
        itemTaken = true;

        if (objectInside != null)
        {
            objectInside.SetActive(false);
        }
    }
}
