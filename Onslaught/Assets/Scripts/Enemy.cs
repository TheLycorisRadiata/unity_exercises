using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    private Rigidbody _rb;
    private Transform _player;
    private float _speed = 5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        Vector3 playerDirection = (_player.position - transform.position).normalized;
        _rb.AddForce(playerDirection * _speed);

        if (transform.position.y < -10f)
            Destroy(gameObject);
    }
}
