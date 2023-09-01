using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _focalPoint;
    [SerializeField] private GameObject _powerupIndicator;
    [SerializeField] private InputActionReference _movementValue;

    private Rigidbody _rb;
    private bool _hasPowerup = false;
    private int _powerUpDuration = 5;
    private float _speed = 550f;
    private float _normalStrength = 10f;
    private float _powerupStrength = 25f;
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
        // Add force to player in direction of the focal point (and camera)
        _rb.AddForce(_focalPoint.forward * _verticalMovement * _speed * Time.deltaTime); 

        // Set powerup indicator position to beneath player
        _powerupIndicator.transform.position = transform.position - new Vector3(0f, 0.65f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            _hasPowerup = true;
            _powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        float strength;
        Vector3 awayFromPlayer;
        Transform enemy = other.gameObject.transform;

        if (!enemy.CompareTag("Enemy"))
            return;

        strength = _hasPowerup ? _powerupStrength : _normalStrength;
        awayFromPlayer = (enemy.position - transform.position).normalized;
        enemy.GetComponent<Rigidbody>().AddForce(awayFromPlayer * strength, ForceMode.Impulse);
    }

    private void VerticalMove(InputAction.CallbackContext context)
    {
        _verticalMovement = context.ReadValue<Vector2>().y;
    }

    private IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(_powerUpDuration);
        _hasPowerup = false;
        _powerupIndicator.SetActive(false);
    }
}
