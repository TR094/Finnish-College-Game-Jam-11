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
        Vector2 handPosition = transform.position;

        Collider2D hit = Physics2D.OverlapPoint(handPosition);

        if (hit == null)
        {
            Debug.Log("Clicked nothing");
            return;
        }

        Debug.Log("Clicked: " + hit.gameObject.name);

        IInteractable interactable =
            hit.GetComponent<IInteractable>();

        if (interactable != null)
        {
            Debug.Log("Found interactable!");
            interactable.Interact();
        }
        else
        {
            Debug.Log("Object is not interactable");
        }
    }
}
