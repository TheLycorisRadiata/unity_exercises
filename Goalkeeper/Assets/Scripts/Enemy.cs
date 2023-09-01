using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    private Rigidbody _enemyRb;
    private Transform _playerGoal;
    private float _speed = 20f;

    private void Awake()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _playerGoal = GameObject.Find("Goals").transform.Find("Player Goal").transform;
    }

    private void FixedUpdate()
    {
        MoveToPlayerGoal();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("Goal"))
            Destroy(gameObject);
    }

    private void MoveToPlayerGoal()
    {
        Vector3 direction = (_playerGoal.position - transform.position).normalized;
        _enemyRb.AddForce(direction * _speed * Time.deltaTime);
    }
}
