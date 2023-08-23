using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float _startY = 7f, _endY = -7f;
    private float _minX = -7f, _maxX = 7f;
    private Rigidbody2D _rb;
    private AudioSource _audioSource;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Spawn();
    }

    private void FixedUpdate()
    {
        if (transform.position.y < _endY)
            Spawn();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _audioSource.Play();
        Freeze();
    }

    private void Spawn()
    {
        Vector3 pos = Vector3.zero;
        pos.y = _startY;
        pos.x = Random.Range(_minX, _maxX);
        
        _rb.velocity = Vector2.zero;
        transform.position = pos;
    }

    private void Freeze()
    {
        _rb.constraints = RigidbodyConstraints2D.FreezePosition;
    }
}
