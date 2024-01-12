using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class PlayerClone : MonoBehaviour
{
    private GameObject clone;
    [SerializeField] private GameObject clonePrefab;
    private PlayerMovement _playerMovement;
    private Transform cloneTransform => clone.transform;

    private void OnEnable()
    {
        InputManager.GameInputAction.Player.Clone.performed += CloneToggle;
    }
    private void OnDisable()
    {
        InputManager.GameInputAction.Player.Clone.performed += CloneToggle;
    }
    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        if (!clone)
        {
            clone = Instantiate(clonePrefab);
            clone.SetActive(false);
        }
    }
    private void CloneToggle(InputAction.CallbackContext toggle)
    {
        if(clone.gameObject.activeSelf)
            CallBackToClonePosition();
        else
            CreateClone();
    }
    private void CreateClone()
    {
        clone.gameObject.SetActive(true);
        clone.transform.position = _playerMovement.GetPlayerPosition();
        cloneTransform.eulerAngles = _playerMovement.GetPlayerRotation();
    }
    private void CallBackToClonePosition()
    {
        _playerMovement.SetPlayerPosition(clone.transform.position);
        _playerMovement.SetPlayerRotation(cloneTransform.eulerAngles);
        clone.gameObject.SetActive(false);
    }
}
