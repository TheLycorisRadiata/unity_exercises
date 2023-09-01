using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private InputActionReference _movementValue;
    private float _speed = 200f;
    private float _horizontalMovement = 0f;

    private void Awake()
    {
        _movementValue.action.started += HorizontalMove;
        _movementValue.action.performed += HorizontalMove;
        _movementValue.action.canceled += HorizontalMove;
    }

    private void LateUpdate()
    {
        transform.Rotate(Vector3.up, _horizontalMovement * _speed * Time.deltaTime);
        MoveFocalPoint();
    }

    private void HorizontalMove(InputAction.CallbackContext context)
    {
        _horizontalMovement = context.ReadValue<Vector2>().x;
    }

    private void MoveFocalPoint()
    {
        transform.position = _player.position;
    }
}
