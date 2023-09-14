using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RoadCheckpoint : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _startPos;
    private Quaternion _startRotation;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _startPos = transform.position;
        _startRotation = transform.rotation;
    }

    private void FixedUpdate()
    {
        if (transform.position.y < _startPos.y - 3f)
        {
            transform.rotation = _startRotation;
            transform.position = _startPos + new Vector3(0f, 1f, 0f);
            _rb.velocity = Vector3.zero;
        }
    }
}
