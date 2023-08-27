using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    public bool gameOver { get; private set; }

    [SerializeField] private InputActionReference _upMovementValue;
    private float _gravityModifier = 1.5f;
    private float _floatForce = 7f;
    private Rigidbody _rb;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip _moneySound;
    [SerializeField] private AudioClip _explodeSound;

    [SerializeField] private ParticleSystem _explosionParticle;
    [SerializeField] private ParticleSystem _fireworksParticle;

    private void Awake()
    {
        gameOver = false;
        Physics.gravity *= _gravityModifier;
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        SubscribeToAction();
    }

    private void Start()
    {
        // Apply a small upward force at the start of the game
        _rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            _explosionParticle.Play();
            _audioSource.PlayOneShot(_explodeSound, 1f);
            Destroy(other.gameObject);
            GameOver();
        }
        else if (other.gameObject.CompareTag("Money"))
        {
            _fireworksParticle.Play();
            _audioSource.PlayOneShot(_moneySound, 1f);
            Destroy(other.gameObject);
        }
    }

    private void SubscribeToAction()
    {
        _upMovementValue.action.started += MoveUp;
    }

    private void UnsubscribeFromAction()
    {
        _upMovementValue.action.started -= MoveUp;
    }

    private void MoveUp(InputAction.CallbackContext context)
    {
        if (transform.position.y > 15f)
            return;
        _rb.AddForce(Vector3.up * _floatForce, ForceMode.Impulse);
    }

    private void GameOver()
    {
        gameOver = true;
        UnsubscribeFromAction();
    }
}
