using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _prefabFood;
    [SerializeField] private InputActionReference _movementValue;
    [SerializeField] private InputActionReference _fireValue;
    private Vector2 _posLimitX = new Vector2(-20f, 20f);
    private Vector2 _posLimitZ = new Vector2(0f, 23f);
    private Vector3 _movementInput = Vector3.zero;
    private float _speed = 25f;

    private void Awake()
    {
        _movementValue.action.started += Move;
        _movementValue.action.performed += Move;
        _movementValue.action.canceled += Move;

        _fireValue.action.started += Fire;
    }

    private void FixedUpdate()
    {
        transform.Translate(_movementInput * _speed * Time.deltaTime);
        ClampPosition();
    }

    private void Move(InputAction.CallbackContext context)
    {
        Vector2 movementVector = context.ReadValue<Vector2>();
        _movementInput = new Vector3(movementVector.x, 0f, movementVector.y);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Instantiate(_prefabFood, transform.position + new Vector3(0f, 0f, 2f), _prefabFood.transform.rotation);
    }

    private void ClampPosition()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, _posLimitX.x, _posLimitX.y);
        pos.z = Mathf.Clamp(pos.z, _posLimitZ.x, _posLimitZ.y);
        if (transform.position != pos)
            transform.position = pos;
    }
}
