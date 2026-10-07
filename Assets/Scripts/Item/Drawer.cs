using UnityEngine;
using UnityEngine.UI;

public class Drawer : MonoBehaviour, IInteractable
{
    public Sprite normalSprite;
    public Sprite openSprite;
    private bool isOpen = false;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void Interact()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            image.sprite = openSprite;
            Debug.Log("drawer is open");
        }
        else
        {
            image.sprite = normalSprite;
            Debug.Log("drawer is closed");
        }
    }
}