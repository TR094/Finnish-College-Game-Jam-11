using UnityEngine;

public class Lamp : MonoBehaviour, IInteractable
{
    public GameObject lightObject;
    public SpriteRenderer lampSprite;

    public Color offColor = Color.gray;
    public Color onColor = Color.yellow;

    private bool isOn = false;

    private void Start()
    {
        lampSprite.color = offColor;
    }

    public void Interact()
    {
        isOn = !isOn;

        lightObject.SetActive(isOn);

        if (isOn)
        {
            lampSprite.color = onColor;
        }
        else
        {
            lampSprite.color = offColor;
        }
    }
}
