using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class RepeatBackground : MonoBehaviour
{
    private float _repeatWidth;
    private Vector3 _startPos;

    private void Awake()
    {
        _repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        _startPos = transform.position;
    }

    private void Update()
    {
        if (transform.position.x < _startPos.x - _repeatWidth)
            transform.position = _startPos;
    }
}
