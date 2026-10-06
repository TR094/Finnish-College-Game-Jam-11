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
            TryInteract();
        }
    }

    private void TryInteract()
    {
        Vector2 mousePosition =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit =
            Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider == null)
            return;

        IInteractable interactable =
            hit.collider.GetComponent<IInteractable>();

        if (interactable != null)
        {
            interactable.Interact();
        }
    }
}
