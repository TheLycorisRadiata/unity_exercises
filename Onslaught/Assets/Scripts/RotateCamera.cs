using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private InputActionReference _movementValue;
    private float _rotationSpeed = 50f;
    private float _horizontalMovement = 0f;

    private void Awake()
    {
        _movementValue.action.started += HorizontalMove;
        _movementValue.action.performed += HorizontalMove;
        _movementValue.action.canceled += HorizontalMove;
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up, _horizontalMovement * _rotationSpeed * Time.deltaTime);
    }

    private void HorizontalMove(InputAction.CallbackContext context)
    {
        _horizontalMovement = context.ReadValue<Vector2>().x;
    }
}
