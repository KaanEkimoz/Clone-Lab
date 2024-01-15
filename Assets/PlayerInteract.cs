using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private SphereCollider interactableSphere;
    private List<IInteractable> _interactableObjects = new();
    private void OnEnable()
    {
        InputManager.GameInputAction.Player.Interact.performed += InteractInput;
    }
    private void OnDisable()
    {
        InputManager.GameInputAction.Player.Interact.performed -= InteractInput;
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
        if (_interactableObjects[0] != null)
        {
            Interact(_interactableObjects[0]);
        }
        
    }
    private void Interact(IInteractable interactable)
    {
        interactable.Interact();
    }
}
