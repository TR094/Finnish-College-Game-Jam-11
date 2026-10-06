using UnityEngine;

public class Hand : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;

        if (Input.GetMouseButtonDown(0))
        {
            TryPickupItem();
        }
    }

    private void TryPickupItem()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            Item item = hit.collider.GetComponent<Item>();

            if (item != null)
            {
                PlayerInventory inventory = FindFirstObjectByType<PlayerInventory>();

                if (inventory != null)
                {
                    if (inventory.AddItem(item))
                    {
                        item.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
