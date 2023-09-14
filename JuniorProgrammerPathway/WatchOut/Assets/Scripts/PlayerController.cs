using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference _movementValue;
    [SerializeField] private TextMeshProUGUI _speedometerText;
    [SerializeField] private TextMeshProUGUI _rpmText;
    private Rigidbody _rb;
    private float _horizontalInput, _verticalInput;
    private float _horsePower, _rotationSpeed = 40f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _horsePower = _rb.mass / 2;

        _movementValue.action.started += Movement;
        _movementValue.action.performed += Movement;
        _movementValue.action.canceled += Movement;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * _rotationSpeed * _horizontalInput * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        int speed = (int)(_rb.velocity.magnitude * 3.6f);
        int rpm = speed % 30 * 40;
        if (speed < 120)
            _rb.AddRelativeForce(Vector3.forward * _horsePower * _verticalInput, ForceMode.Impulse);
        _speedometerText.text = speed + " km/h";
        _rpmText.text = rpm + " RPM";
    }

    private void Movement(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        _horizontalInput = input.x;
        _verticalInput = input.y;
    }
}
