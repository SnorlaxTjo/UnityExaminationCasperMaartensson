using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] InteractType interactType;
    [SerializeField] GameObject interactDisplayObject;
    [SerializeField] KeyCode interactKey = KeyCode.E;

    [Header("Menu")]
    [SerializeField] GameObject menuToDisplay;
    [SerializeField] bool removeAfterMenu;

    [Header("Pickup")]
    [SerializeField] UnityEvent whatToDoUponPickup;

    bool playerIsInInteractSpace;

    private void Update()
    {
        interactDisplayObject.SetActive(playerIsInInteractSpace);

        if (playerIsInInteractSpace && Input.GetKeyDown(interactKey))
        {
            Interact();
        }
    }

    void Interact()
    {
        switch (interactType)
        {
            case InteractType.Menu:
                menuToDisplay.SetActive(!menuToDisplay.activeSelf);
                //PlayerMovement.Instance.MoveBlock = menuToDisplay.activeSelf;

                if (!menuToDisplay.activeSelf && removeAfterMenu)
                {
                    gameObject.SetActive(false);
                }
                break;

            case InteractType.Pickup:
                whatToDoUponPickup?.Invoke();
                gameObject.SetActive(false);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsInInteractSpace = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsInInteractSpace = false;
        }
    }

    private enum InteractType
    {
        Menu,
        Pickup
    }
}
