/*using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour 
{
    private Transform PlayerTransform => gameObject.transform;
    [SerializeField] private float moveSpeed = 5;
    private Vector3 _moveInput;
    private GameInputActions _gameInput;

    private Vector3 forward,right;
    private void Start()
    {
        if (Camera.main != null) forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    private void OnEnable()
    {
        InputManager.GameInputAction.Player.Move.performed += GatherInput;
        InputManager.GameInputAction.Player.Move.canceled += CancelMovement;
    }

    private void OnDisable()
    {
        InputManager.GameInputAction.Player.Move.performed -= GatherInput;
        InputManager.GameInputAction.Player.Move.canceled -= CancelMovement;
    }
    private void FixedUpdate() 
    {
        Move();
    }

    private void GatherInput(InputAction.CallbackContext value)
    {
        Vector2 moveVector = value.ReadValue<Vector2>();
        _moveInput = new Vector3(moveVector.x, 0, moveVector.y);
    }

    private void CancelMovement(InputAction.CallbackContext value)
    {
        _moveInput = Vector3.zero;
    }
    private void Move()
    {
        if(_moveInput == Vector3.zero)
            return;
        
        Vector3 direction = new Vector3(_moveInput.x, 0, _moveInput.y);
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * _moveInput.x;
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * _moveInput.z;
        
        Vector3 heading = Vector3.Normalize((rightMovement + upMovement));

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }
    private void ShiftPlayerForward()
    {
        
    }

    public Vector3 GetPlayerRotation()
    {
        return PlayerTransform.eulerAngles;
    }
    public void SetPlayerRotation(Vector3 rot)
    {
        PlayerTransform.eulerAngles = rot;
    }
    public Vector3 GetPlayerPosition()
    {
        return PlayerTransform.position;
    }
    public void SetPlayerPosition(Vector3 pos)
    {
        PlayerTransform.position = pos;
    }
}*/
