using System;
using UnityEngine;

public class Hand : MonoBehaviour
{

    [SerializeField] private Vector2 cursorOffset;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        transform.position = mousePos + (Vector3)cursorOffset;

        if (Input.GetMouseButtonDown(0))
        {
            TryInteract();
        }
    }

    private void TryInteract()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Collider2D hit = Physics2D.OverlapPoint(mousePos);

        if (hit == null)
        {
            Debug.Log("Clicked nothing");
            return;
        }

        Debug.Log("Clicked: " + hit.gameObject.name);

        IInteractable interactable = hit.GetComponent<IInteractable>();

        if (interactable != null)
        {
            Debug.Log("Found interactable!");
            interactable.Interact();
        }
    }

}