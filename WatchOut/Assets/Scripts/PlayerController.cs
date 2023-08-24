using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference _movementValue;
    private float _horizontalInput, _verticalInput;
    private float _forwardSpeed = 20f, _sideSpeed = 40f;

    private void Awake()
    {
        _movementValue.action.started += Movement;
        _movementValue.action.performed += Movement;
        _movementValue.action.canceled += Movement;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _forwardSpeed * _verticalInput * Time.deltaTime);
        transform.Rotate(Vector3.up * _sideSpeed * _horizontalInput * Time.deltaTime);
    }

    private void Movement(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        _horizontalInput = input.x;
        _verticalInput = input.y;
    }
}
