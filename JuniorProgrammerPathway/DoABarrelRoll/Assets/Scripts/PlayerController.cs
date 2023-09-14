using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference _movementValue;
    private float _verticalInput = 0f;
    private float _forwardSpeed = 6f;
    private float _rotationSpeed = 12f;

    private void Awake()
    {
        _movementValue.action.started += Movement;
        _movementValue.action.canceled += Movement;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _forwardSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right * _rotationSpeed * _verticalInput * Time.deltaTime);
    }

    private void Movement (InputAction.CallbackContext context)
    {
        _verticalInput = context.ReadValue<Vector2>().y;
    }
}
