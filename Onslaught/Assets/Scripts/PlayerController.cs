using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference _movementValue;
    [SerializeField] private Transform _focalPoint;
    private Rigidbody _rb;
    private float _speed = 5f;
    private float _verticalMovement = 0f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _movementValue.action.started += VerticalMove;
        _movementValue.action.performed += VerticalMove;
        _movementValue.action.canceled += VerticalMove;
    }

    private void FixedUpdate()
    {
        _rb.AddForce(_focalPoint.forward * _verticalMovement * _speed);
    }

    private void VerticalMove(InputAction.CallbackContext context)
    {
        _verticalMovement = context.ReadValue<Vector2>().y;
    }
}
