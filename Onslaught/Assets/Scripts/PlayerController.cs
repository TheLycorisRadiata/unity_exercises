using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference _movementValue;
    [SerializeField] private Transform _focalPoint;
    [SerializeField] private GameObject _strengthPowerupIndicator, _firePowerupIndicator;
    [SerializeField] private GameObject _gameOverScreen;
    private AudioSource _gameOverSound;
    private GameObject _powerupIndicator = null;
    private bool _hasStrengthPowerup = false;
    private Rigidbody _rb;
    private float _verticalMovement = 0f;
    private float _speed = 5f;
    private float _powerupStrength = 15f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _gameOverSound = GetComponent<AudioSource>();
        _movementValue.action.started += VerticalMove;
        _movementValue.action.performed += VerticalMove;
        _movementValue.action.canceled += VerticalMove;
    }

    private void FixedUpdate()
    {
        _rb.AddForce(_focalPoint.forward * _verticalMovement * _speed);
        if (_powerupIndicator != null)
            PlaceIndicatorBelowPlayer();
        if (transform.position.y < -10f)
            GameOver();
    }

    private void VerticalMove(InputAction.CallbackContext context)
    {
        _verticalMovement = context.ReadValue<Vector2>().y;
    }

    private void PlaceIndicatorBelowPlayer()
    {
        _powerupIndicator.transform.position = transform.position - new Vector3(0f, 0.6f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;
        if (!tag.Contains("Powerup"))
            return;

        Destroy(other.gameObject);
        if (tag.StartsWith("Strength"))
        {
            _hasStrengthPowerup = true;
            _powerupIndicator = _strengthPowerupIndicator;
        }
        else
        {
            _powerupIndicator = _firePowerupIndicator;
            PushAllEnemiesAway();
        }
        PlaceIndicatorBelowPlayer();
        _powerupIndicator.SetActive(true);
        StartCoroutine(PowerupCountdownRoutine());
    }

    private IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        _powerupIndicator.SetActive(false);
        _hasStrengthPowerup = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject enemy = collision.gameObject;
        if (_hasStrengthPowerup && enemy.CompareTag("Enemy"))
            PushEnemyAway(enemy, 1);
    }

    private void PushEnemyAway(GameObject enemy, int multiplier)
    {
        Rigidbody enemyRb = enemy.GetComponent<Rigidbody>();
        Vector3 awayFromPlayer = (enemy.transform.position - transform.position).normalized * multiplier;
        enemyRb.AddForce(awayFromPlayer * _powerupStrength, ForceMode.Impulse);
    }

    private void PushAllEnemiesAway()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
            PushEnemyAway(enemy.gameObject, 2);
        _powerupIndicator.SetActive(false);
    }

    private void GameOver()
    {
        _gameOverScreen.SetActive(true);
        _gameOverSound.Play();
        Time.timeScale = 0f;
    }
}
