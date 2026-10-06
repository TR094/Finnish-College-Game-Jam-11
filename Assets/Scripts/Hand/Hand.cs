using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] public SpriteRenderer itemRenderer;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = mousePos;
    }

    public void HoldItem(Sprite itemSprite)
    {
        itemRenderer.sprite = itemSprite;
    }
}
