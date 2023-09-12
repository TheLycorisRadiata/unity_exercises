using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveForward : MonoBehaviour
{
    private Rigidbody _rb;
    private float _horsePower;
    private bool _isGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _horsePower = _rb.mass / 2;
    }

    private void FixedUpdate()
    {
        if (_isGrounded)
            _rb.AddRelativeForce(Vector3.forward * _horsePower, ForceMode.Impulse);
    }

    private void OnCollisionEnter()
    {
        _isGrounded = true;
    }

    private void OnCollisionExit()
    {
        _isGrounded = false;
    }
}
