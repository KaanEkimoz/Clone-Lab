using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour 
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float turnSpeed = 360;
    private Vector3 _input;
    private IsometricCharacterController controller;

    private void Awake()
    {
        controller = new IsometricCharacterController();
    }

    private void OnEnable()
    {
        
        controller.Enable();
        controller.Player.Move.performed += GatherInput;
        controller.Player.Move.canceled += CancelMovement;
    }

    private void OnDisable()
    {
        controller.Disable();
        controller.Player.Move.performed -= GatherInput;
        controller.Player.Move.canceled -= CancelMovement;
    }

    private void Update() {
        Look();
    }

    private void FixedUpdate() 
    {
        Move();
    }

    private void GatherInput(InputAction.CallbackContext value)
    {
        Vector2 moveVector = value.ReadValue<Vector2>();
        _input = new Vector3(moveVector.x, 0, moveVector.y);
    }

    private void CancelMovement(InputAction.CallbackContext value)
    {
        Vector2 moveVector = Vector2.zero;
        _input = new Vector3(moveVector.x, 0, moveVector.y);
    }

    private void Look() {
        if (_input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
    }

    private void Move() {
        rigidBody.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * moveSpeed * Time.deltaTime);
    }
}

public static class Helpers 
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}
