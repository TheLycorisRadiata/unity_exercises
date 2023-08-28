using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public bool gameOver { get; private set; }
    public int speedMultiplier { get; private set; }
    [SerializeField] private InputActionReference _jumpValue;
    [SerializeField] private InputActionReference _dashValue;
    [SerializeField] private ParticleSystem _explosionParticle, _dirtParticle;
    [SerializeField] private AudioClip _jumpSound, _crashSound;
    [SerializeField] private TextMeshProUGUI _scoreTmpro;
    [SerializeField] private GameObject _gameOverText;
    private Animator _anim;
    private Rigidbody _rb;
    private AudioSource _audioSource;
    private float _jumpForce = 20f;
    private int _allowedJumps = 2;
    private int _score = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        gameOver = false;
        speedMultiplier = 1;
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        Physics.gravity = new Vector3(0f, -50f, 0f);

        _jumpValue.action.started += Jump;
        _dashValue.action.started += Dash;
        _dashValue.action.canceled += Dash;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _dirtParticle.Play();
            _allowedJumps = 2;
        }
        else
            GameOver();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            _score += speedMultiplier;
            _scoreTmpro.text = "Score: " + _score.ToString();
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (_allowedJumps == 0)
            return;
        _anim.SetTrigger("Jump_trig");
        _audioSource.PlayOneShot(_jumpSound, 1f);
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _dirtParticle.Stop();
        --_allowedJumps;
    }

    private void Dash(InputAction.CallbackContext context)
    {
        speedMultiplier = context.canceled ? 1 : 2;
        _anim.speed = (float)speedMultiplier;
    }

    private void GameOver()
    {
        if (gameOver)
            return;

        // If jump right before game over: player can end up on top of the obstacle, so put them back onto the ground
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);

        gameOver = true;
        _allowedJumps = 0;
        _explosionParticle.Play();
        _dirtParticle.Stop();
        _audioSource.PlayOneShot(_crashSound, 1f);
        DeathAnimation();
        _gameOverText.SetActive(true);
    }

    private void DeathAnimation()
    {
        _anim.speed = 1f;
        _anim.SetBool("Death_b", true);
        _anim.SetInteger("DeathType_int", 1);
    }
}
