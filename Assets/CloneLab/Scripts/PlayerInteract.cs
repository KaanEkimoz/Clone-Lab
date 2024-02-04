using System;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private SphereCollider interactableSphere;
    private List<IInteractable> _interactableObjects = new();
    private StarterAssetsInputs _input;

    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
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

    private void FixedUpdate()
    {
        InteractInput();
    }

    private void FindNearestInteractable()
    {
    }
    private void InteractInput()
    {
        if (_input.interact)
        {
            Interact(_interactableObjects[0]);

            _input.interact = false;
        }
        
    }
    private void Interact(IInteractable interactable)
    {
        interactable.Interact();
    }
}
