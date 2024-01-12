using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private SphereCollider interactableSphere;
    private List<IInteractable> _interactableObjects;
    private void OnEnable()
    {
        InputManager.GameInputAction.Player.Interact.performed += InteractInput;
    }
    private void OnDisable()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var interactable = other.gameObject.GetComponent<IInteractable>();
        if(interactable != null)
            _interactableObjects.Add(interactable);
    }
    private void OnTriggerExit(Collider other)
    {
        var interactable = other.gameObject.GetComponent<IInteractable>();
        if(interactable != null)
            _interactableObjects.Remove(interactable);
    }

    private void FindNearestInteractable()
    {
    }

    private void InteractInput(InputAction.CallbackContext value)
    {
        Interact(_interactableObjects[0]);
    }
    private void Interact(IInteractable interactable)
    {
        interactable.Interact();
    }
}
